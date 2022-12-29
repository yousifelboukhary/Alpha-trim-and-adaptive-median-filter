using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static ImageFilters.SortHelper;
namespace ImageFilters
{
    class AlphaTrimFilter
    {
        public static Byte[,] ApplyFilter(Byte[,] ImageMatrix, int MaxWindowSize, int UsedAlgorithm, int TrimValue)
        {
           
            Byte[,] NewImageMatrix = ImageMatrix;
            int numOfLoops = manyLoops(MaxWindowSize); 
            
            for (int i = numOfLoops; i < ImageMatrix.GetLength(0)-numOfLoops; i++)
            {
                for (int j = numOfLoops; j < ImageMatrix.GetLength(1)-numOfLoops; j++)
                {
                    
                    ArrayList bytes = new ArrayList();
                    int left = j - numOfLoops;
                    int right = j + numOfLoops;
                    int top = i - numOfLoops;
                    int buttom = i + numOfLoops;
                    int x = numOfLoops;
                    while (x >numOfLoops-1)
                    {
                        x--;
                        for (int s = left; s <= right; s++)
                        {
                            bytes.Add( ImageMatrix[top, s]);
                        }

                        top++;
                        for (int s = top; s <= buttom; s++)
                        {
                            bytes.Add( ImageMatrix[s, right]);

                        }

                        right--;
                        for (int s = right; s >= left; s--)
                        {
                            bytes.Add(ImageMatrix[buttom, s]);
                        }

                        buttom--;
                        for (int s = buttom; s >= top; s--)
                        {
                            bytes.Add(ImageMatrix[s, left]);
                        }

                        left++;
                    }

                    bytes.Add(ImageMatrix[i, j]);
                    int n = bytes.Count;
                    Byte[] ArrayBytes = new Byte[n];
                    for (int k = 0; k < ArrayBytes.Length; k++)
                    {
                        ArrayBytes[k] = (byte)bytes[k];
                    }
                    if (UsedAlgorithm == 0)
                    {
                        ArrayBytes = CountingSort(ArrayBytes);
                        int avg = 0;
                        for (int s = TrimValue; s < ArrayBytes.Length - TrimValue; s++)
                        {
                            avg += ArrayBytes[s];
                        }

                        if (ArrayBytes.Length == TrimValue * 2)
                            return new byte[ImageMatrix.GetLength(0),ImageMatrix.GetLength(1)];
                        avg = avg / (ArrayBytes.Length - (TrimValue * 2));
                        NewImageMatrix[i, j] =(byte) avg;
                    }
                    
                    else
                    {
                        NewImageMatrix[i, j] = Kth_element(ArrayBytes, TrimValue);

                    }
                }
            }

            return NewImageMatrix;

        }
        
        private static int manyLoops(int W)
        {
            int ans = 0;
            while (W>1)
            {
                ans++;
                W -= 2;
            }
            return ans;
        }
        
    }
    
}
