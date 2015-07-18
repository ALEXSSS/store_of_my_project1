

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

struct {
	short bfType; //тип файла, символы «BM»
	unsigned long bfSize; //размер файла
	unsigned short bfReserved1; //предположительно для корректности передачи
	unsigned short bfReserved2;
	unsigned long bfOffBits; /*смещение в байтах от начала структуры BITMAPFILEHEADER 
							до непосредственно битов изображения.*/
} BITMAPFILEHEADER;

typedef struct {
	unsigned int biSize;
	int biWidth; //может быть отрицателен
	int biHeight;
	unsigned short biPlanes;
	unsigned short biBitCount; //Количество бит на пиксель
	unsigned int biCompression;
	unsigned int biSizeImage;
	int biXPelsPerMeter;
	int biYPelsPerMeter;
	unsigned int biClrUsed;
	unsigned int biClrImportant;
} bitmapinfoheader;
bitmapinfoheader BITMAPINFOHEADER;

typedef struct {
	unsigned char rgbBlue;
	unsigned char rgbGreen;
	unsigned char rgbRed;
} RGB;
int chek;

int main(int argc, char** argv)
{
	if(argc != 4)
	{
		printf("Sorry, error datum");
		printf("%s %s %s", argv[0], argv[1], argv[2]);
	}
	else
	{
		int i;
		FILE* BMP = fopen(argv[1], "r");
		printf("Enter name of the outfile: ");
		FILE* BMP1 = fopen(argv[2], "w");

		if(BMP == NULL)
		{
			printf("Sorry error, repeat pleas\n");
		}
		else
		{
			fread(&BITMAPFILEHEADER.bfType, 2, 1, BMP);
			char* pz = (char*) &BITMAPFILEHEADER.bfType;

			if(BITMAPFILEHEADER.bfType == 19778)
			{
				printf("Type of the file: BMP");
				fread(&BITMAPFILEHEADER.bfSize, 4, 1, BMP);
				fread(&BITMAPFILEHEADER.bfReserved1, 2, 1, BMP);
				fread(&BITMAPFILEHEADER.bfReserved2, 2, 1, BMP);
				fread(&BITMAPFILEHEADER.bfOffBits, 4, 1, BMP);

				fread(&BITMAPINFOHEADER.biSize, 4, 1, BMP);
				fread(&BITMAPINFOHEADER.biWidth, 4, 1, BMP);
				fread(&BITMAPINFOHEADER.biHeight, 4, 1, BMP);
				fread(&BITMAPINFOHEADER.biPlanes, 2, 1, BMP);
				fread(&BITMAPINFOHEADER.biBitCount, 2, 1, BMP);
				fread(&BITMAPINFOHEADER.biCompression, 4, 1, BMP);
				fread(&BITMAPINFOHEADER.biSizeImage, 4, 1, BMP);
				fread(&BITMAPINFOHEADER.biXPelsPerMeter, 4, 1, BMP);
				fread(&BITMAPINFOHEADER.biYPelsPerMeter, 4, 1, BMP);
				fread(&BITMAPINFOHEADER.biClrUsed, 4, 1, BMP);
				fread(&BITMAPINFOHEADER.biClrImportant, 4, 1, BMP);
				int j, i;
				printf("\nHeight %d, Width %d\nNumbers pixel: %d. \n", BITMAPINFOHEADER.biHeight, BITMAPINFOHEADER.biWidth, BITMAPINFOHEADER.biHeight * BITMAPINFOHEADER.biWidth);
				RGB** pok;
				pok = (RGB**) malloc(sizeof(RGB*) * BITMAPINFOHEADER.biHeight);
				for(i = 0; i < BITMAPINFOHEADER.biHeight; i++)
				{
					pok[i] = (RGB*) malloc(sizeof(RGB) * BITMAPINFOHEADER.biWidth);
				}
				int k, k1; //...............................
				k = (4 - (BITMAPINFOHEADER.biWidth * 3) % 4) % 4;

				unsigned char mus = 0;
				for(i = 0; i < abs(BITMAPINFOHEADER.biHeight); i++)
				{
					for(j = 0; j < abs(BITMAPINFOHEADER.biWidth); j++)
					{
						RGB rgb;
						fread(&rgb.rgbBlue, 1, 1, BMP);
						fread(&rgb.rgbGreen, 1, 1, BMP);
						fread(&rgb.rgbRed, 1, 1, BMP);
						pok[i][j].rgbBlue = rgb.rgbBlue;
						(pok[i][j]).rgbGreen = rgb.rgbGreen;
						((pok[i][j])).rgbRed = rgb.rgbRed;
					}
					//printf("%d %d %d\n", pok[i][j].rgbBlue, rgb.rgbGreen, rgb.rgbBlue);
					for(k1 = 0; k1 < k; k1++)
					{
						fread(&mus, 1, 1, BMP);
					}

				}//.........................считывания файла, корректный случай
				//.............,..дополнения фильтрами.............................
				menu();
				switch(atoi(argv[3])) {
					case (1): medium_filtr(BMP1, pok);
						break;
					case (2): convolution(BMP1, pok);
						break;
					case (3): filtr_Gaussa_blur(BMP1, pok);
						break;
					case (4): filtr_Sobel_x(BMP1, pok);
						break;
					case (5): filtr_Sobel_y(BMP1, pok);
						break;
					case (6): filtr_Gaussa_x(BMP1, pok);
						break;
					case (7): filtr_Gaussa_y(BMP1, pok);
						break;
					case (8): filtr_Happy(BMP1, pok);
						break;
					case (9): pasta(BMP1, pok);
						break;
					case (10): filtr_Color(BMP1, pok);
						break;
					case (11): filtr_Sobel_x_y(BMP1, pok);
						break;
					case (12): filtr_Gaussa_x_y(BMP1, pok);
						break;
				}
			}
			else
			{
				printf("File no correct.\n");
				printf("\n%c%c\n", *pz, *pz + 1);
				getchar();
				getchar();
				fclose(BMP);
				fclose(BMP1);
			}
		}
		fclose(BMP);
	}

	return(EXIT_SUCCESS);
}

int menu()
{
	printf("Choise filtr image and enter directly number:\n");
	printf("1)Medium filtr.\n");
	printf("2)Convolution.\n");
	printf("3)Filtr Gaussa blur\n");
	printf("4)Filtr Sobel to x\n");
	printf("5)Filtr Sobel to y\n");
	printf("6)Filtr Gaussa to x\n");
	printf("7)Filtr Gaussa to y\n");
	printf("  Other filtrs for large objects\n");
	printf("8)Happy\n");
	printf("9)Pasta\n");
	printf("10)Color filtr\n");
	printf("11)Filtr Sobel to x and y (sunny)\n");
	printf("12)Filtr Gaussa to x and y\n");
}

int filtr_Color(FILE* BMP, RGB** p)
{
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = -0.5;
	c[0][1] = 0.75;
	c[0][2] = 0.5;
	c[1][0] = 0.75;
	c[1][1] = 2;
	c[1][2] = 0.75;
	c[2][0] = 0.5;
	c[2][1] = 0.75;
	c[2][2] = -0.5;
	outf(c, p, BMP, 1, 0, 0);
	getchar();
	getchar();
}

int filtr_Gaussa_x(FILE* BMP, RGB** p)
{
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 0;
	c[0][1] = 0;
	c[0][2] = 0;
	c[1][0] = -1;
	c[1][1] = 0;
	c[1][2] = 1;
	c[2][0] = 0;
	c[2][1] = 0;
	c[2][2] = 0;
	outf(c, p, BMP, 1, 0, 1);
	getchar();
	getchar();
}

int filtr_Gaussa_y(FILE* BMP, RGB** p)
{
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 0;
	c[0][1] = -1;
	c[0][2] = 0;
	c[1][0] = 0;
	c[1][1] = 0;
	c[1][2] = 0;
	c[2][0] = 0;
	c[2][1] = 1;
	c[2][2] = 0;
	outf(c, p, BMP, 1, 0, 1);
}

int filtr_Gaussa_x_y(FILE* BMP, RGB** p)
{
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 0;
	c[0][1] = -1;
	c[0][2] = 0;
	c[1][0] = -1;
	c[1][1] = 0;
	c[1][2] = 1;
	c[2][0] = 0;
	c[2][1] = 1;
	c[2][2] = 0;
	outf(c, p, BMP, 2, 0, 1);
	getchar();
	getchar();
}

int pasta(FILE* BMP, RGB** p)
{
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 0;
	c[0][1] = -1;
	c[0][2] = 0;
	c[1][0] = -1;
	c[1][1] = 0;
	c[1][2] = 1;
	c[2][0] = 0;
	c[2][1] = 1;
	c[2][2] = 0;
	outf(c, p, BMP, 2, 0, 0);
	getchar();
	getchar();
}

int medium_filtr(FILE* BMP, RGB** p)
{
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 1;
	c[0][1] = 1;
	c[0][2] = 1;
	c[1][0] = 1;
	c[1][1] = 1;
	c[1][2] = 1;
	c[2][0] = 1;
	c[2][1] = 1;
	c[2][2] = 1;
	//...........................
	outf(c, p, BMP, 9, 1, 1);
	getchar();
	getchar();
}

int convolution(FILE* BMP, RGB** p)
{
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 0.5;
	c[0][1] = 0.75;
	c[0][2] = 0.5;
	c[1][0] = 0.75;
	c[1][1] = 1;
	c[1][2] = 0.75;
	c[2][0] = 0.5;
	c[2][1] = 0.75;
	c[2][2] = 0.5;
	outf(c, p, BMP, 6, 1, 1);
}

int filtr_Sobel_x(FILE* BMP, RGB** p)
{
	//...........................создание матрицы фильтра
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = -1;
	c[0][1] = 0;
	c[0][2] = 1;
	c[1][0] = -2;
	c[1][1] = 0;
	c[1][2] = 2;
	c[2][0] = -1;
	c[2][1] = 0;
	c[2][2] = 1;
	outf(c, p, BMP, 1, 0, 1);
}

int filtr_Sobel_y(FILE* BMP, RGB** p)
{
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = -1;
	c[0][1] = -2;
	c[0][2] = -1;
	c[1][0] = 0;
	c[1][1] = 0;
	c[1][2] = 0;
	c[2][0] = 1;
	c[2][1] = 2;
	c[2][2] = 1;
	outf(c, p, BMP, 1, 0, 1);
}

int filtr_Sobel_x_y(FILE* BMP, RGB** p)
{
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 2;
	c[0][1] = 2;
	c[0][2] = 0;
	c[1][0] = 2;
	c[1][1] = 0;
	c[1][2] = 2;
	c[2][0] = 0;
	c[2][1] = 2;
	c[2][2] = 2;
	outf(c, p, BMP, 2, 0, 1);
}

int filtr_Gaussa_blur(FILE* BMP, RGB** p)
{
	int chek;
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 0.06163058;
	c[0][1] = 0.12499331;
	c[0][2] = 0.06163058;
	c[1][0] = 0.12499331;
	c[1][1] = 0.25355014;
	c[1][2] = 0.12499331;
	c[2][0] = 0.06163058;
	c[2][1] = 0.12499331;
	c[2][2] = 0.06163058;
	outf(c, p, BMP, 1, 1, 1);
}

int filtr_Happy(FILE* BMP, RGB** p)
{
	float** c;
	c = (float**) malloc(sizeof(float*)*3);
	for(chek = 0; chek < 3; chek++)
	{
		c[chek] = (float*) malloc(sizeof(float)*3);
	}
	c[0][0] = 0.5;
	c[0][1] = 0.75;
	c[0][2] = 0.5;
	c[1][0] = 0.75;
	c[1][1] = 1;
	c[1][2] = 0.75;
	c[2][0] = 0.5;
	c[2][1] = 0.75;
	c[2][2] = 0.5;
	outf(c, p, BMP, 1, 1, 0);
}

int outf(float** c, RGB** p, FILE* BMP, int div, int first, int bl)
{
	fwrite(&BITMAPFILEHEADER.bfType, 2, 1, BMP);
	fwrite(&BITMAPFILEHEADER.bfSize, 4, 1, BMP);
	fwrite(&BITMAPFILEHEADER.bfReserved1, 2, 1, BMP);
	fwrite(&BITMAPFILEHEADER.bfReserved2, 2, 1, BMP);
	fwrite(&BITMAPFILEHEADER.bfOffBits, 4, 1, BMP);

	fwrite(&BITMAPINFOHEADER.biSize, 4, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biWidth, 4, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biHeight, 4, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biPlanes, 2, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biBitCount, 2, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biCompression, 4, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biSizeImage, 4, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biXPelsPerMeter, 4, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biYPelsPerMeter, 4, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biClrUsed, 4, 1, BMP);
	fwrite(&BITMAPINFOHEADER.biClrImportant, 4, 1, BMP);
	int k, j, i, i1;
	unsigned char zero = 0;
	k = (4 - (BITMAPINFOHEADER.biWidth * 3) % 4) % 4;
	unsigned char red, green, blue;
	int i12, j1, red1 = 0, green1 = 0, blue1 = 0;
	unsigned char black = 255;
	if(first == 1)
	{
		for(i = 0; i < abs(BITMAPINFOHEADER.biWidth); i++)
		{
			fwrite(&p[0][i].rgbBlue, 1, 1, BMP);
			fwrite(&p[0][i].rgbGreen, 1, 1, BMP);
			fwrite(&p[0][i].rgbRed, 1, 1, BMP);
		}
	}
	else
	{
		for(i = 0; i < abs(BITMAPINFOHEADER.biWidth); i++)
		{
			fwrite(&black, 1, 1, BMP);
			fwrite(&black, 1, 1, BMP);
			fwrite(&black, 1, 1, BMP);
		}
	}
	for(i = 0; i < k; i++)
	{
		fwrite(&zero, 1, 1, BMP);
	}
	for(i = 1; i < abs(BITMAPINFOHEADER.biHeight) - 1; i++)
	{
		if(first == 1)
		{
			fwrite(&p[i][0].rgbBlue, 1, 1, BMP);
			fwrite(&p[i][0].rgbGreen, 1, 1, BMP);
			fwrite(&p[i][0].rgbRed, 1, 1, BMP);
		}
		else
		{
			fwrite(&black, 1, 1, BMP);
			fwrite(&black, 1, 1, BMP);
			fwrite(&black, 1, 1, BMP);
		}
		for(j = 1; j < abs(BITMAPINFOHEADER.biWidth) - 1; j++)
		{
			for(i12 = 0; i12 < 3; i12++)
				for(j1 = 0; j1 < 3; j1++)
				{
					red1 = red1 + p[i + i12 - 1][j + j1 - 1].rgbRed * c[i1][j1];
					blue1 = blue1 + p[i + i12 - 1][j + j1 - 1].rgbBlue * c[i1][j1];
					green1 = green1 + p[i + i12 - 1][j + j1 - 1].rgbGreen * c[i1][j1];
				}
			blue = (unsigned char) (bl != 0 ? (blue1 / div) > 255 ? 255 : (blue1 / div) < 0 ? 0 : (blue1 / div) : blue1);
			red = (unsigned char) (bl != 0 ? (red1 / div) > 255 ? 255 : (red1 / div) < 0 ? 0 : (red1 / div) : red1);
			green = (unsigned char) (bl != 0 ? (green1 / div) > 255 ? 255 : (green1 / div) < 0 ? 0 : (green1 / div) : green1);
			red1 = blue1 = green1 = 0;
			fwrite(&blue, 1, 1, BMP);
			fwrite(&green, 1, 1, BMP);
			fwrite(&red, 1, 1, BMP);
		}
		if(first == 1)
		{
			fwrite(&p[i][BITMAPINFOHEADER.biWidth - 1].rgbBlue, 1, 1, BMP);
			fwrite(&p[i][BITMAPINFOHEADER.biWidth - 1].rgbGreen, 1, 1, BMP);
			fwrite(&p[i][BITMAPINFOHEADER.biWidth - 1].rgbRed, 1, 1, BMP);
		}
		else
		{
			fwrite(&black, 1, 1, BMP);
			fwrite(&black, 1, 1, BMP);
			fwrite(&black, 1, 1, BMP);
		}
		for(i1 = 0; i1 < k; i1++)
		{
			fwrite(&zero, 1, 1, BMP);
		}
	}
	if(first == 1)
	{
		for(i = 0; i < abs(BITMAPINFOHEADER.biWidth); i++)
		{
			fwrite(&p[BITMAPINFOHEADER.biHeight - 1][i].rgbBlue, 1, 1, BMP);
			fwrite(&p[BITMAPINFOHEADER.biHeight - 1][i].rgbGreen, 1, 1, BMP);
			fwrite(&p[BITMAPINFOHEADER.biHeight - 1][i].rgbRed, 1, 1, BMP);
		}
	}
	else
	{
		for(i = 0; i < abs(BITMAPINFOHEADER.biWidth); i++)
		{
			fwrite(&black, 1, 1, BMP);
			fwrite(&black, 1, 1, BMP);
			fwrite(&black, 1, 1, BMP);
		}
	}
	for(i1 = 0; i1 < k; i1++)
	{
		fwrite(&zero, 1, 1, BMP);
	}
	printf("complete!");
	fclose(BMP);
}
