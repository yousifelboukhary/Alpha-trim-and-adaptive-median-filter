# Alpha-trim-and-adaptive-median-filter
<h1>The main idea</h1>
The main idea of both filters is to sort the pixel values 
in a neighborhood region with certain window size and then 
chose/calculate the single value from them and places it in the center of the window in a new image, 
see figure 1. This process is repeated for all pixels in the original image.
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
<h2>Adaptive Median Filter</h2>
<p>The idea of the standard median filter is similar to alpha-trim filter 
  but instead we calculate the median of neighboring pixels' values (middle value in the window array after sorting). 
</p>
<p>
  However, the standard median filter has the following drawbacks:
  <dt>
<li>It fails to remove salt and pepper noise with large percentage (greater than 20%) without causing distortion in the original image.</li>
<li>It usually has a side-effect on the original image especially when it’s applied with large mask size, see figure 2 with window 7×7.</li> 
    </dt>
</p>
<br>
<br>
<p>
  <strong>Adaptive median filter</strong> is designed to handle these drawbacks by:
  <dt>
<li>Seeking a median value that’s not either salt or pepper noise by increasing the window size until reaching such median.</li>
<li>Replace the noise pixels only. (i.e. if the pixel is not a salt or a pepper, then leave it).</li> 
    </dt>
</p>
