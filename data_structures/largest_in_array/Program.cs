//T1 Marcus

int[] arr = {5, 7, 9, -2, -5, 12, 4, 6, 7, 3};

//Assume the array has at least one value, and that the
//first could be the largest
int largestNumberFound = arr[0];

//Start the loop at 1, because index 0 is used as the default largest value
for (int i = 1; i < arr.Length; i++) {
	//If any number in the array is larger than the currently stored largest number, replace it
	if (arr[i] > largestNumberFound)
		largestNumberFound = arr[i];
}

Console.WriteLine(largestNumberFound);
