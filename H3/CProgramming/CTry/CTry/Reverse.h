#include <stdio.h>
#include <string.h>

void rString(char* text, int length)
{
	char temp;
	int i;
	for (i = 0; i < length / 2; i++)
	{
		temp = text[i];
		text[i] = text[length - i - 1];
		text[length - i - 1] = temp;
	}
}