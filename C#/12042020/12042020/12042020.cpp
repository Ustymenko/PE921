#include <iostream>
#include <Windows.h>
#include <ctime>
#include <algorithm>
using namespace std;
int Max(int**& arr, int r, int c) {
    int max;
    max = 0;
    for (int j = 0; j < r; j++) {
        for (int i = 0; i < c; i++)
        {
            if (arr[j][i] > max) max = arr[j][i];
        }
    }
    return max;
}
void Pmax(int**& arr, int pmax, int c, int r, int* k, int* l) {
    for (int j = 0; j < r; j++) {
        for (int i = 0; i < c; i++) {
            if (arr[i][j] == pmax) {
                (*k) = i;
                (*l) = j;
            }
        }
    }
}
int main()
{
    const int sizer = 100, sizec = 100;
    int r, c, a = -20, b = 20, k = 0, l = 0;
    int* pk = &k;
    int* pl = &l;
    cout << "Input r="; cin >> r;
    cout << "Input c="; cin >> c;
    if (r<1 or r>sizer) return 0;
    if (c<1 or c>sizec) return 0;
    int** arr = new int* [r];
    for (size_t i = 0; i < r; i++)
        arr[i] = new int[c] { 0 };
    srand(time(0));
    for (int j = 0; j < r; j++) {
        for (int i = 0; i < c; i++) {
            arr[j][i] = a + rand() % (b - a + 1);
        }
    }
    for (int j = 0; j < r; j++) {
        for (int i = 0; i < c; i++) {
            cout << arr[j][i] << '\t';
        }
        cout << endl;
    }
    cout << "MAx = " << Max(arr, r, c) << endl;
    int pmax = Max(arr, r, c);
    Pmax(arr, pmax, c, r, &k, &l);
    cout << "Pol " << k << " : " << l;
}