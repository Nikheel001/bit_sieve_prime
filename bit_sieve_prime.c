#include<stdio.h>
int cp = sizeof(int)<<3;
int cln = 0;
void cln_init()
{
	int k = cp;
	while(k>>=1)
		cln++;
}
// should not use val __builtin_ctz(cp) as cln
// or use it as constant variable means #define cln __builtin_ctz(cp)
#define __BIG__ 10000
// set bit
#define Sbit(A,x) ( A[x>>cln] |= (1 << (x%cp)) )
//clear bit
#define Cbit(A,x) ( A[x>>cln] &= ~(1 << (x%cp)) )
//test bit
#define Tbit(A,x) ( A[x>>cln] & (1 << (x%cp)) )

// we can store upto cp*__BIG__ prime numbers
// future developments 2-D array
// (different | big) data type
int arr[__BIG__];

void sieve_init(int n)
{
	int i,j,req = n>>cln;
	memset(arr,-1,req);
	arr[0]=-4;
	for(i=2;i<n;i++)
		if(Tbit(arr,i))
			for(j=(i<<1);j<=n;j+=i)
				Cbit(arr,j);
}

void test_em(int from,int to)
{
	while(from<=to)
	{
		if(Tbit(arr,from))
			printf("%d ",from);
		from++;
	}
}

int main()
{
	cln_init();
	printf("%d\n",cln);
	sieve_init(100000);
//	test_em(100,300);
//	test_em(400,900);
//	test_em(700,1200);
//	test_em(10000,100000);
//	test_em(1000000,1005000);
//	test_em(0,1365577);
	test_em(0,1000);
	return 0;
}
