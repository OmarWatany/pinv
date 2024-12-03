// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
unsafe
{
  [DllImport("libc", CharSet = CharSet.Auto, SetLastError = true)]
  static extern void* malloc(UInt64 size);

  [DllImport("libc", CharSet = CharSet.Auto, SetLastError = true)]
  static extern void free(void* addr);

  int[] a = { 1, 2, 3, 4, 5 };
  int sz = a.Length;

  int* arr = (int*)malloc((ulong)sz * sizeof(int));
  for (int i = 0; i < sz; i++)
    *((int*)arr + i) = a[i];

  for (int i = 0; i < sz; i++)
  {
    System.Console.WriteLine(*((int*)arr + i));
  }
  free(arr);
}
