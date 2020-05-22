#include <iostream>
#include <Windows.h>

using namespace std;
void FillArray(int** arr, int n, int m) {
    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++) {
            arr[i][j] = 2;
        }
}
void ShowArray(int** arr, int n, int m) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }
}
void DeleteArray(int** arr, int n) {

    for (int i = 0; i < n; i++) {
        delete[]arr[i];
    }
    delete[]arr;
}
int** AddStroki(int** oldArr, int& r, int c, int CountRowAdd) {
    //new arr
    int** arr = new int* [r + CountRowAdd];
    for (int i = 0; i < r + CountRowAdd; i++) 
        arr[i] = new int[c] {0};
    //copy elementy
    for (int i = 0; i < r; i++) 
        for (int j = 0; j < c; j++) 
                arr[i][j] = oldArr[i][j];   

    DeleteArray(oldArr, r);
    // new count row
    r = r + CountRowAdd;
    return arr;
    
}

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);
    int col = 0, row = 0;
    cout << "Введите количество столбцов : " << endl;
    cin >> col;
    cout << "Введите количество строк: " << endl;
    cin >> row;
    int** mas = new int* [row];
    for (int i = 0; i < row; i++) {
        mas[i] = new int[col];
    }
    FillArray(mas,row, col );
    cout << endl;
    ShowArray(mas, row, col);
    cout << endl;
    cout << "Введите количество строк для добавления: " << endl;
    int c;
    cin >> c;

    mas=AddStroki(mas,row ,col,  c);
    ShowArray(mas, row, col);

    DeleteArray(mas, row);
}