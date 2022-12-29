using System;

namespace ImageFilters
{
    class AdaptiveMedianFilter
    {

        public static Byte[,] ApplyFilter(Byte[,] ImageMatrix, int MaxWindowSize, int UsedAlgorithm)
        {
            Byte[,] newimage = ImageMatrix;
            Byte Zxy, Zmax, Zmin, Zmed, A1, A2, B1, B2;
            Zxy = 0;
            int k = 3;

            for (int i = 0; i < ImageMatrix.GetLength(0) - k; i++)
            {
                // column of first cell in current sub-square of
                // size k x k
                for (int j = 0; j < ImageMatrix.GetLength(1) - k; j++)
                {
                    int m = i, n = j;
                    while (true)
                    {

                        int centerX = -1, centerY = -1;
                        Byte[] arr = new Byte[k * k];
                        int counter = 0;
                        for (int s = m; s < k + m; s++)
                            for (int t = n; t < k + n; t++)
                            {
                                arr[counter] = ImageMatrix[s, t];

                                if (counter == (k * k) / 2)
                                {
                                    Zxy = ImageMatrix[s, t];
                                    //get center of window index
                                    centerX = s; centerY = t;
                                }
                                counter++;
                             
                            }
                        if (UsedAlgorithm == 0)
                            //quick sort
                            arr = SortHelper.QuickSort(arr,0,arr.Length-1);
                        else if (UsedAlgorithm == 1)
                            arr = SortHelper.CountingSort(arr);
                        Zmin = arr[0];
                        Zmax = arr[arr.Length - 1];
                        Zmed = arr[(arr.Length + 1) / 2];
                        A1 = (Byte)(Zmed - Zmin);
                        A2 = (Byte)(Zmax - Zmed);
                        if (A1 > 0 && A2 > 0)
                        {
                            B1 = (Byte)(Zxy - Zmin);
                            B2 = (Byte)(Zmax - Zxy);
                            if (B1 > 0 && B2 > 0)
                            {
                                newimage[centerX, centerY] = Zxy;
                                break;
                            }
                            else
                            {
                                newimage[centerX, centerY] = Zmed;
                                break;
                            }
                        }
                        else
                        {
                            k += 2;
                            if (k <= MaxWindowSize && m - 1 >= 0 && n - 1 >= 0 && m < ImageMatrix.GetLength(0) - k && n < ImageMatrix.GetLength(1) - k)
                            {
                                
                                m -= 1;
                                n -= 1;
                                continue;
                            }

                            else
                            {
                                newimage[centerX, centerY] = Zmed;
                                break;
                            }
                        }
                    }
                    k = 3;


                }
            }

            return newimage;
        }

    }
}

