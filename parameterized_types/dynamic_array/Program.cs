//T1 Marcus

//NOTE: This exercise is pretty tough. I have left a lot of comments, but they may still not make much sense on their own.
//Feel free to ask me if you find anything confusing. You can also text me on ItsLearning (You can find me under participants 
//in the OOP course), though I might not notice immediately.

class Program {
	public static void Main(string[] args) {
		//Test code taken from the exercise
		DynamicArray<int> a = new DynamicArray<int>(10);
		
		Console.WriteLine("Add elements:");
		Console.WriteLine(a);
		
		for (int i=0 ; i<20 ; i++) {
			a.Append(i);
			Console.WriteLine(a);
		}
		Console.WriteLine("");
		
		Random random = new Random();
		Console.WriteLine("Remove elements:");
		Console.WriteLine(a);
		for (int i=19 ; i>=0 ; i--) {
			a.Remove(random.Next(a.GetFill()));
			Console.WriteLine(a);
		}

		//Extra manual test code for insert, get and set
		Console.WriteLine("\nManual Testing:");
		a.Append(5);
		a.Append(11);
		a.Append(7);
		Console.WriteLine(">>Print: " + a);
		
		Console.WriteLine("Get [1]: " + a.Get(1));
		
		Console.WriteLine("Set [2] = -3");
		a.Set(2, -3);
		Console.WriteLine(">>Print: " + a);
		
		Console.WriteLine("Insert at [2]: 99");
		a.Insert(2, 99);
		Console.WriteLine(">>Print: " + a);
		
		Console.WriteLine("Remove at [1]");
		a.Remove(1);
		Console.WriteLine(">>Print: " + a);

		Console.WriteLine("Get [1]: " + a.Get(1));

		Console.WriteLine("Remove  at [0]");
		a.Remove(0);
		Console.WriteLine(">>Print: " + a);
	}
}


//Interface taken from exercise
interface IDynArray<T>
{
	void Append (T element);
	void Insert (int i, T element);
	void Remove (int i);
	void Set (int i, T element);
	T Get (int i);
	int GetFill ();
}



//Both the new class and the implemented interface must have the generic <T>.
class DynamicArray<T>: IDynArray<T> {
	//Capacity can always be found using 'data.Length' However, feel free to use the variable if it seems more intuitive.
	//I have created a minimumCapacity, that can be set using the constructor.
	private T[] data;
	private int minimumCapacity;
	private int fill;


	//Constructor
	public DynamicArray(int minimumCapacity) {
		this.data = new T[minimumCapacity];
		this.minimumCapacity = minimumCapacity;
		this.fill = 0;
	}

	public void Append(T element) {
		//Append should always add the element to the far right side of the array,
		//so that any new element added will have the highest index of elements in the array!

		//If the array is full, we need to expand it before adding more elements.
		if (fill == data.Length)
			ExpandArray();

		//We can use the fill variable to assign a new element. If fill is currently 1, that means
		//only index 0 has been used, so index 1 is the next free one. This works as long as there
		//are no empty slots inbetween our elements.
		data[fill] = element;
		fill++;
	}

	public void Insert(int index, T element) {
		//We don't want to modify the array indices that contain no real data. We also want to ensure no gaps in the real data.
		if (index > fill) {
			Console.WriteLine("Cannot insert at ["+ index +"] as the position is invalid. We could throw an exception here!");
			return;
		}

		//If the array is full, we need to expand it before adding more elements.
		if (fill == data.Length)
			ExpandArray();

		//Start from the end of the filled elements, and work backwards until we reach the specified index.
		//While iterating, we move each point of data one slot to the right.
		for (int i = fill; i > index; i--)
			data[i] = data[i-1];

		//We override the current element at the index (which has already been safely stored at 'index + 1').
		data[index] = element;
		fill++;
	}

	public void Remove(int index) {
		//We don't want to modify the array indices that contain no real data.
		if (index >= fill) {
			Console.WriteLine("Index [" + index + "] is outside 'real' elements. We could throw an exception here!");
			return;
		}

		//Move all data to the right of the specified index one slot to the left, overwritting the value at the index.
		//Some data has not actually been deleted, but by keeping track of our fill level, it is now outside
		//of the 'filled' part of the array.
		for (int i = index; i < fill - 1; i++) {
			data[i] = data[i + 1];
		}

		fill--;

		//If the array has become less than half filled, we shrink it.
		if (fill < data.Length / 2)
			ShrinkArray();

	}

	public void Set(int index, T element) {
		//We don't want to expose the array indices that contain no real data.
		if (index >= fill) {
			Console.WriteLine("Index [" + index + "] is outside 'real' elements. We could throw an exception here!");
			return;
		}

		//Override the data at the index.
		data[index] = element;
	}

	public T Get(int index) {
		//We don't want to expose the array indices that contain no real data.
		if (index >= fill) {
			//An exception seems more correct here, since we are trying to return data.
			Console.WriteLine("Index [" + index + "] is outside 'real' elements. We SHOULD throw an exception here!");
			return default(T);
		}

		return data[index];
	}

	public int GetFill() {
		return fill;
	}

	private void ExpandArray() {
		//Create a new array twice the size of the current data array
		T[] largerArray = new T[data.Length * 2];

		//Copy over all elements from the data array to the new larger array
		for (int i = 0; i < data.Length; i++) {
			largerArray[i] = data[i];
		}

		//Swap the reference. Data now contains the larger array, while the old data has 
		//been dereferenced and will be deleted by the garbage collector.
		data = largerArray; 
	}

	//This method is for shrinking the array, and should only be called if it has been checked 
	//that the fill level is less than half of the capacity!
	private void ShrinkArray() {
		//If halving the array would make it smaller than the minimum capacity, we use the minimum capacity as the new size.
		int newSize = data.Length / 2 < minimumCapacity ? minimumCapacity : data.Length / 2;
		T[] smallerArray = new T[newSize];

		//Since all elements should be compressed to the left of the array, we should not worry about gaps in the data, 
		//and it should neatly fit into the smaller array.
		for (int i = 0; i < smallerArray.Length; i++) {
			smallerArray[i] = data[i];
		}

		//Swap the reference. Data now contains the smaller array, while the old data has 
		//been dereferenced and will be deleted by the garbage collector.
		data = smallerArray; 
	}

	override public string ToString() {
		string str = "[";
		for (int i = 0; i < fill; i++) {
			str += data[i];
			str += (i == fill - 1 ? "" : ",");
		}
		str += "]";
		return str;
	}
}
