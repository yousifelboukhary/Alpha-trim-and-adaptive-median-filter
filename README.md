# Alpha-trim-and-adaptive-median-filter
<h1>The main idea</h1>
The main idea of both filters is to sort the pixel values 
in a neighborhood region with certain window size and then 
chose/calculate the single value from them and places it in the center of the window in a new image, 
see figure 1. This process is repeated for all pixels in the original image.
<br>
<br>
<br>

<img src="https://user-images.githubusercontent.com/114557942/210007073-a8b86c2a-d056-4b3c-bb6b-f74b88a2dd33.PNG" alt="image one" title="filters image">
<br>
<h2>Alpha Trim filter</h2>
<p>
The idea is to calculate the average of some neighboring pixels' values after
trimming out (excluding) the smallest T pixels and largest T pixels. This can be done by 
repeating the following steps for each pixel in the image:
  <dt>
  <li>Store the values of the neighboring pixels in an array. The array is called the window, and it should be odd sized.</li>
    <li>Sort the values in the window in ascending order.</li>
    <li>Exclude the first T values (smallest) and the last T values (largest) from the array.</li>
    <li>Calculate the average of the remaining values as the new pixel value and place it in the center of the window in the new image, see figure 1.</li>
  </dt>
  <br>
  This filter is usually used to remove both salt & pepper noise and random noise. 
</p>
<p>
  <img src= "https://user-images.githubusercontent.com/114557942/210009252-d90c5280-a9de-4408-8fb8-1f0cbc53902a.PNG" alt="alpha trim 5*5" title ="alpha trim 5*5 with trim value = 3" >
</p>
<hr>

<br>
<br>
  <h3>The implementation of Alpha Trim filter using Kth element and Count sort <h3>
    <img src = "https://user-images.githubusercontent.com/114557942/210011178-3af88f7b-2018-4ffb-a0f1-ad03b64379e2.png" alt ="adaptive execution time graph" title ="adaptive execution time graph">
    <h3>Graph discription</h3>
    The graph above shows how the execution time changes with respect to the window 
size in the Alpha Trim Filter using Counting Sort verses Kth Element algorithm to 
sort the pixels in each window.
    <br>
    <br>
      <h3>Conclusion</h3>
    As we can see in the graph, the execution time of Counting Sort and Kth Element 
Algorithm appears to be very similar. This is because Counting Sort and Kth 
Element algorithms both have a time complexity of O(N).
However, Counting Sort seems to perform slightly better as it has a fewer number 
of operations in comparison to the Counting Sort algorithm.
In regards to space Complexity, Counting Sort and Kth Element algorithms both 
have O(n) space complexity.
Therefore, in our case, we can say that both algorithms performed equally well 
however Counting Sort was slightly better.    
<hr>
<br>
<br>
<h2>Adaptive Median Filter</h2>
<p>The idea of the standard median filter is similar to alpha-trim filter 
  but instead we calculate the median of neighboring pixels' values (middle value in the window array after sorting). 
</p>


<p>
  However, the standard median filter has the following drawbacks:
  <dt>
<li>It fails to remove salt and pepper noise with large percentage (greater than 20%) without causing distortion in the original image.</li>
<li>It usually has a side-effect on the original image especially when it???s applied with large mask size, see figure 2 with window 7??7.</li> 
    </dt>
</p>
<br>
<br>
<p>
  <strong>Adaptive median filter</strong> is designed to handle these drawbacks by:
  <dt>
<li>Seeking a median value that???s not either salt or pepper noise by increasing the window size until reaching such median.</li>
<li>Replace the noise pixels only. (i.e. if the pixel is not a salt or a pepper, then leave it).</li> 
    </dt>
</p>
<p>
  <img src="https://user-images.githubusercontent.com/114557942/210010184-3f8d1bcc-323f-44ce-b407-fc13770e66c5.PNG" title="adaptive median filter" alt ="adaptive median filter">
  <img src = "https://user-images.githubusercontent.com/114557942/210010366-a7256918-ab1d-43df-8132-8694d5ad574f.jpg" title="adaptive median filter" alt ="adaptive median filter">
</p>
<hr>
<p>
  <h3>The implementation of Adaptive median filter using Quick Sort and Count sort <h3>
    <img src = "https://user-images.githubusercontent.com/114557942/210011178-3af88f7b-2018-4ffb-a0f1-ad03b64379e2.png" alt ="adaptive execution time graph" title ="adaptive execution time graph">
    <h3>Graph discription</h3>
    The graph above shows how the execution time changes with respect to the window 
size in the Adaptive Median Filter using Quick Sort verses Counting Sort to sort the 
pixels in each window.
    <br>
    <br>
      <h3>Conclusion</h3>
    Sorts aren't always necessarily better than one another. In certain situations, 
quicksort might be preferred for a number of reasons:
Quicksort is in place, unlike counting sort, which has to create a number of arrays 
(e.g. use more memory) to do its work.
It may seem like counting sort is O(n) but consider the intermediate counting array 
that must be created. The counting array length is essentially the difference 
between the largest and smallest elements in your original array. If the range is very 
big, this counting array is massive and this counting array has to be processed. So 
really, the run time of counting sort is O(N+k) where k is the difference between 
the largest and smallest elements in the original array.
In regards to space complexity, Quick Sort wins as it has O(log(N)) space 
complexity while Counting Sort has O(n) space complexity.
Therefore, in our case, we can say that Quick Sort performed better in the Adaptive 
Median Filter.

    
    
</p>
