using System;
using ReactiveUI;

namespace Amir.ViewModels;
public class TranspositionSortVm : PageVm
{
    public TranspositionSortVm(IScreen hostScreen) : base(hostScreen)
    {
    }

    public override int[] Execute(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return Array.Empty<int>();
        }

        var n = arr.Length;
        bool swapped;
        var operationsCount = 0; 

        do
        {
            swapped = false;
            for (var i = 1; i < n; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
                    swapped = true;
                    operationsCount += 3;
                }
                operationsCount++;
            }
            n--; 
            operationsCount++; 
        } while (swapped);

        var memoryAllocate = arr.Length * sizeof(int); 

        OperationsCount = operationsCount;
        MemoryAlocate = memoryAllocate;

        return arr;
    }
}
