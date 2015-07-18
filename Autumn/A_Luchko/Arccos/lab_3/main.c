#include <stdio.h>
#include <math.h>

int main()
{
	short k;
	float a, b, c, a1, b1, c1, pi, a2, b2, c2;
	k = 1;
	while(k == 1)
	{
		printf("Enter the three sides of the triangle: ");
		if((scanf("%f %f %f", &a, &b, &c) == 3) && (a + b > c && b + c > a && a + c > b))
		{

			pi = M_PI;

			c1 = acos((a * a + b * b - c * c) / (2.0 * a * b));

			a1 = acos((c * c + b * b - a * a) / (2.0 * c * b));

			b1 = acos((c * c + a * a - b * b) / (2.0 * a * c));

			a1 = (a1 / pi) * 180;
			b1 = (b1 / pi) * 180;
			c1 = (c1 / pi) * 180;
			a2 = (int) ((a1 - (int) a1) * 60);
			b2 = (int) ((b1 - (int) b1) * 60);
			c2 = (int) ((c1 - (int) c1) * 60);
			printf("The angles of a triangle: 1)%0.f deg %0.f min ", a1, a2);
			printf(" 2)%0.f deg %0.f min", b1, b2);
			printf(" 3)%0.f deg %0.f min", c1, c2);
			k = 2;
			getchar();
			getchar();
		}
		else
		{
			printf("Sorry, no correct\n");
			scanf("%*[^\n]");
		}
	}
	return (0);
}