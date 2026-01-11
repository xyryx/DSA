package arrays

import "testing"

func TestRemoveDuplicates(t *testing.T) {
	tests := []struct {
		input    []int
		expected int
		output   []int
	}{
		{input: []int{1, 1, 2}, expected: 2, output: []int{1, 2}},
		{input: []int{0, 0, 1, 1, 1, 2, 2, 3, 3, 4}, expected: 5, output: []int{0, 1, 2, 3, 4}},
		{input: []int{99, 100, 100}, expected: 2, output: []int{99, 100}},
		{input: []int{1, 2, 3}, expected: 3, output: []int{1, 2, 3}},
		{input: []int{}, expected: 0, output: []int{}},
		{input: []int{-100, -50, 0, 50, 100}, expected: 5, output: []int{-100, -50, 0, 50, 100}},
	}

	for _, test := range tests {
		k := removeDuplicates(test.input)
		if k != test.expected {
			t.Errorf("removeDuplicates(%v) = %d; expected %d", test.input, k, test.expected)
		}
		for i := 0; i < k; i++ {
			if test.input[i] != test.output[i] {
				t.Errorf("modified array to %v; expected %v", test.input, test.output)
				break
			}
		}
	}
}
