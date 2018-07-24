using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;

class Solution {

    // Complete the commonChild function below.
    static int commonChild(string s1, string s2) 
    {
        char []first= s1.ToCharArray();
        char[]second= s2.ToCharArray();
        int length1=s1.Length;
        int length2=s2.Length;
        int i, j;
        int [ , ] maximum =new int[length1 , length2];
      
    for(i=0;i<length1;i++){
        if(first[i]==second[0])
            maximum[i,0]=1;
        else if(i!=0)
            maximum[i ,0]=maximum[i-1 ,0];
        else
            maximum[i ,0]=maximum[i ,0];
    }

    for(j=1;j<length2;j++){
        if(first[0]==second[j])
            maximum[0 ,j]=1;
        else
            maximum[0 ,j]=maximum[0 ,j-1];
    }



    for(i=1;i<length1;i++)
    {
        for(j=1;j<length2;j++){
            if(first[i]==second[j])
                maximum[i ,j]=maximum[i-1 ,j-1]+1;
            else if(maximum[i-1 ,j]>= maximum[i ,j-1])
                maximum[i ,j]=maximum[i-1 ,j];
            else
                maximum[i ,j]=maximum[i ,j-1];
        }
    }


     return maximum[length1-1 ,length2-1];



    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = commonChild(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
