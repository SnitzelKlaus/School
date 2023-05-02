#include <stdio.h>
#include <string.h>

int countWords(char* text, int length)
{
	int count = 0;
	int i;
	for (i = 0; i < length; i++)
	{
		if (text[i] == ' ')
		{
			count++;
		}
	}
	return count + 1;
}

int orderWords(char* ptr, int length)
{
	// Orders words by alphabet
	int i, j;
	char temp;

	for (i = 0; i < length; i++)
	{

	}
}
