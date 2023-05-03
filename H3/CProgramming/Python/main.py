import random
import time


# Selection sort algorithm


def selectionSort(arr):
    for i in range(len(arr)-1):
        for j in range(i+1, len(arr)):
            if arr[j] < arr[i]:
                arr[i], arr[j] = arr[j], arr[i]

# Insertion sort algorithm


def insertionSort(arr):
    for i in range(1, len(arr)):
        key = arr[i]
        j = i-1
        while j >= 0 and key < arr[j]:
            arr[j+1] = arr[j]
            j -= 1
        arr[j+1] = key


# Array with 1000000 integers-
size = 100000
arr = [size]

# Adds random integers to the array
for i in range(size):
    arr.append(random.randint(0, size))

print("Sorting array of size: " + str(size) + "\n")

# Timer
tic = time.perf_counter()  # Start Time

insertionSort(arr)
# selectionSort(arr)

toc = time.perf_counter()  # End Time

# Prints the time taken in seconds
print(f"Time taken: {toc - tic} seconds")
