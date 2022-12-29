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

<hr>
<br>
<br>
<br>
<br>
