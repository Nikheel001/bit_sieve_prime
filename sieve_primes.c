#include<stdio.h>
#include<stdbool.h>
#include<stdlib.h>
#define __BIG__ 100000
bool arr[__BIG__];

void sieve_init(int n)
{
	int i,j;
	memset(arr,1,n);
	arr[0] = false; arr[1] = false;
	for(i=2;i<n;i++)
		if(arr[i])
			for(j=(i<<1);j<=n;j+=i)
				arr[j]=false;
}

void test_em(int from,int to)
{
	while(from<=to)
	{
		if(arr[from])
			printf("%d ",from);
		from++;
	}
}

int main()
{
	sieve_init(100000);
	test_em(0,1000);
	return 0;
}
