using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques
{
    class SmapperSO
    {
        //shows the basic sort
        [PluginDescription("For HomeDepotHUB, StaplesHUB, QuillHub, and StaplesAQHUB, lookup Xref for Discontinued field and set DiscontinueDate to current day in XMLDocs")]
        [PluginAttribute("Acumatica", "MappingModule", "AfterDoWork", 1)]
        public int[] SetPoLineNumber1(int[] array)//GFan 833261    Insertion Sort Ascending
        {
            int index;
            int temp;
            
            // create a temporary array for subsequent processing
            int[] tempArray = new int[array.Length + 1];
            tempArray[0] = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i + 1] = array[i];
            }

            // main processing procedure
            for (int i = 2; i < tempArray.Length; i++)
            {
                index = i;
                temp = tempArray[i];
                for (int j = 0; j < i; j++)
                {
                    if (tempArray[i] > tempArray[j] && tempArray[i] <= tempArray[j+1])
                    {
                        for (int k = i; k > j+1; k--)
                        {
                            tempArray[k] = tempArray[k-1];
                        }
                        tempArray[j + 1] = temp;
                        break;
                    }
                }
            }

            // Take the number from index 1 to the last from the array
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = tempArray[i+1];
            }

            return array;
        }
    }
}
