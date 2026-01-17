package main

func getConcatenation(nums []int) []int {
	arr := make([]int, len(nums)*2)

	for i, num := range nums {
		arr[i] = num
		arr[i+len(nums)] = num
	}

	return arr

}
