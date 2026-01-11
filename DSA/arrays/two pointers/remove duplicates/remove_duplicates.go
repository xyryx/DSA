package arrays

import "fmt"

// func removeDuplicates(nums []int) int {

// 	end := len(nums) - 1
// 	i := 0
// 	if end < 0 {
// 		return 0
// 	}
// 	for i < end {
// 		if nums[i] > nums[i+1] {
// 			break
// 		}

// 		if nums[i] < nums[i+1] {
// 			i++
// 			continue
// 		}

// 		if nums[i] == nums[i+1] {
// 			match := nums[i+1]
// 			nums = append(nums[:i+1], nums[i+2:]...)
// 			nums = append(nums, match)

// 			end = end - 1
// 		}
// 	}

// 	return i + 1
// }

func removeDuplicates(nums []int) int {

	l := 1

	if len(nums) == 0 {
		return 0
	}

	for r := 1; r < len(nums); r++ {
		if nums[r] != nums[r-1] {
			nums[l] = nums[r]
			l++
		}
	}

	return l
}

func main() {
	nums := []int{99, 100, 100}
	k := removeDuplicates(nums)

	for i := 0; i < k; i++ {
		fmt.Printf("%v ", nums[i])
	}
	fmt.Printf("\n")

}
