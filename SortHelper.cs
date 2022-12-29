using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ImageFilters
{
    class SortHelper
    {

        public static Byte Kth_element(Byte[] Array, int k)
        {
            List<byte> newList = new List<byte>(Array);
            for (int i = k; i > 0; i--)
            {
                newList.RemoveAt(newList.IndexOf(FindKthSmallest(Array, i)));

            }

            for (int i = k; i > 0; i--)
            {

                newList.RemoveAt(newList.IndexOf(FindKthLargest(Array, i)));
            }
            
            int sum = 0;
            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i] < 0)
                    continue;
                sum += newList[i];
            }

            return (byte)(sum / newList.Count);
            
        }
        private static byte FindKthSmallest(byte[] nums, int k) {
        
            int left = 0, right = nums.Length - 1;
            int expectedIdx = nums.Length - k;
        
            while(left <= right)
            {
                int pivotLoc = PartitionSmallest(nums, left, right);
            
                if(pivotLoc == expectedIdx)
                    return nums[expectedIdx];
                else if(pivotLoc < expectedIdx)
                    left = pivotLoc + 1;
                else
                    right = pivotLoc - 1;
            }
        
            return Byte.MinValue;
        }
        
        private static byte FindKthLargest(byte[] nums, int k) {
        
            int left = 0, right = nums.Length - 1;
            int expectedIdx = nums.Length - k;
        
            while(left <= right)
            {
                int pivotLoc = PartitionLargest(nums, left, right);
            
                if(pivotLoc == expectedIdx)
                    return nums[expectedIdx];
                else if(pivotLoc < expectedIdx)
                    left = pivotLoc + 1;
                else
                    right = pivotLoc - 1;
            }
        
            return Byte.MinValue;
        }
        private static int PartitionSmallest(byte[] nums, int left, int right)
        {
            int pivot = nums[right];
            int pivotLoc = left;
            for(int i = left; i < right; i++)
            {
                if(nums[i] > pivot)
                {
                    Swap(nums, i, pivotLoc);
                    pivotLoc++;
                }
            }
        
            Swap(nums, pivotLoc, right);
        
            return pivotLoc;
        }
        private static int PartitionLargest(byte[] nums, int left, int right)
        {
            int pivot = nums[right];
            int pivotLoc = left;
            for(int i = left; i < right; i++)
            {
                if(nums[i] < pivot)
                {
                    Swap(nums, i, pivotLoc);
                    pivotLoc++;
                }
            }
        
            Swap(nums, pivotLoc, right);
        
            return pivotLoc;
        }
    
        private static void Swap(byte[] nums, int i, int j)
        {
            byte temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        
        
        public static Byte[] CountingSort(Byte[] Array)
        {
            Byte[] bytes = new byte[256];
            for (int i = 0; i < Array.Length; i++)
            {
                bytes[Array[i]]++;
            }
            Byte[] SortedArr = new byte[Array.Length];
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                while (bytes[i] > 0)
                {
                    SortedArr[j] = (Byte)i;
                    bytes[i]--;
                    j++;
                }
            }
            Array = SortedArr;
            return Array;
        }

        private static int partition(Byte[] Array, int l , int h/*last index*/)
        {
            int i;  //loop iterator
            int p;  //pivot index
            int firstHigh;    
            
            p = h; 
            firstHigh = l;
            for (i = l; i < h; i++)
            {
                if (Array[i] < Array[p])
                {
                    
                    //Swapping
                    Byte temp = Array[i];
                    Array[i] = Array[firstHigh];
                    Array[firstHigh] = temp;
                    firstHigh++;
                }
            }

            Byte temp2 = Array[p];
            Array[p] = Array[firstHigh];
            Array[firstHigh] = temp2;
            return firstHigh;
        }
        public static byte[] QuickSort(Byte[] Array,int l,int h)
        {
            int p;
            if (l < h)
            {
                p = partition(Array, l, h);
                QuickSort(Array, l, p - 1);
                QuickSort(Array, p + 1, h);
            }
            return Array;
        }
    }
}
