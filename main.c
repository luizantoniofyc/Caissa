//
//  main.c
//  Mat4
//
//  A Method for Generating Security Assessment Criteria - Coverage calculus
//
//  Created by Ferrucio de Franco Rosa on 01/12/2016.
//  Copyright (c) 2016 Ferrucio de Franco Rosa. All rights reserved.
//
// Last modified: 01/12/2016.
//

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/*
 General Sequence:
 read_Arq_In(arq.txt);
 receive ID, listaDM, listaPP;
 cov_calc(CovDM, CovPP, CovLOC);
 write_Arq_Out(CovDM+CovPP+CovLOC);
 
 Simulation - Knowledge Source 1 (KS1)
 
 ID         ListDM    ListPP         CovDM    CovPP    CovLOC
 5.1.1		000100    11010010101    ?        ?        ?
 5.1.2		110100    11010001010    ?        ?        ?
 6.1.1		010010    10110010100    ?        ?        ?
 6.1.2		100100    01001010101    ?        ?        ?
 6.1.3		100100    11010001010    ?        ?        ?
 */

float cov_calc(float A,int B)
{ float coverage=0.0;
    if (A == 0.0) return 0.0; // Min. Coverage = 0.0;
    else
        if ((coverage=A/B) >= 1.0) return 1.0; // Max. Coverage = 1.0;
        else return coverage;
}


// Dimension Matrix
float MatDM[6][6] =
{
    {0.0, 0.5, 0.2,	0.6, 0.7, 0.9},
    {0.0, 0.0, 0.9,	0.7, 0.6, 0.8},
    {0.0, 0.0, 0.0,	0.4, 0.2, 0.6},
    {0.0, 0.0, 0.0,	0.0, 0.5, 0.2},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.8},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.0},
};
// Property Matrix
float MatPP[11][11] =
{
    {0.0, 0.9, 0.9,	0.9, 0.8, 0.8, 0.8, 0.8, 0.5, 0.2, 0.8},
    {0.0, 0.0, 0.9,	0.9, 0.8, 0.8, 0.8, 0.8, 0.5, 0.2, 0.2},
    {0.0, 0.0, 0.0,	0.9, 0.8, 0.8, 0.2, 0.8, 0.5, 0.8, 0.8},
    {0.0, 0.0, 0.0,	0.0, 0.2, 0.2, 0.8, 0.6, 0.5, 0.8, 0.4},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.2, 0.4, 0.6, 0.5, 0.8, 0.2},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.0, 0.5, 0.2, 0.5, 0.8, 0.2},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.0, 0.0, 0.8, 0.5, 0.2, 0.8},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.0, 0.0, 0.0, 0.5, 0.2, 0.2},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.5, 0.5},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.2},
    {0.0, 0.0, 0.0,	0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
};

// SumDist DM & PP
float sumDist(char *list)
{
    int i, j;
    long len = strlen(list);
    float SumDist=0.0;
    for (i=0;i<len;i++){//printf("List[%d]: %c \n", i+1, list[i]);
        if(list[i] == '1'){ //printf("List[%d]: %c \n", i+1, list[i]);
            for (j=0;j<len;j++){
                if(len==6){
                    if (MatDM[i][j]>0.0 && list[j] == '1') {//printf(" DistanceDM(%d,%d): %.2f \n", i+1, j+1, MatDM[i][j]);
                        SumDist = SumDist + MatDM[i][j];
                    }
                }
                else{
                    if (MatPP[i][j]>0.0 && list[j] == '1') {//printf(" DistancePP(%d,%d): %.2f \n", i+1, j+1, MatPP[i][j]);
                        SumDist = SumDist + MatPP[i][j];
                    }
                }
            }
        }
    }
    return SumDist;
}

int main(int argc, char * argv[]) {
    int MAX_DM = 6, MAX_PP = 11;
    float SumDistDM = 0.0, SumDistPP = 0.0;
    float CovDM=0.0, CovPP=0.0, CovLOC=0.0; /* Coverages */
    char coverage[19];
    char urlin[]="/Users/ferruciof/Desktop/2015/Doutorado/RESULTADOS/Software/Mat4/Mat4/in.txt";
    char urlout[]="/Users/ferruciof/Desktop/2015/Doutorado/RESULTADOS/Software/Mat4/Mat4/out.txt";
    char line[20]="";
    char listDM[20]="";
    char listPP[20]="";
    FILE *FIn,*FOut;
    
    FIn = fopen(urlin, "r");
    FOut = fopen(urlout, "w");
    
    if(FIn == NULL)
        printf("Error, FIn access. \n");
    else
    if(FOut == NULL)
        printf("Error, FOut access. \n");
    else
        while( (fscanf(FIn,"%s\n", line))!=EOF )
        {
            strncpy ( listDM, line, 6 ); //Select Dimensions
            strncpy ( listPP, &line[6], 11 ); // Select Properties
   
            // Calculate sum of distances DM & PP
            SumDistDM = sumDist(listDM);
            SumDistPP = sumDist(listPP);
    
            // Calculate converage DM & PP
            CovDM = cov_calc(SumDistDM, MAX_DM);
            CovPP = cov_calc(SumDistPP, MAX_PP);
    
            // Calculate converage LOC
            CovLOC = cov_calc((CovDM+CovPP), 2);
    
            sprintf(coverage, "%.3f;%.3f;%.3f;", CovDM, CovPP, CovLOC);
            printf("\n%s;%s;%s\n", listDM, listPP, coverage);
            fprintf(FOut,"%s\n", coverage); // Write FOut
        }
    fclose(FIn);
    fclose(FOut);
    
    return 0;
}
