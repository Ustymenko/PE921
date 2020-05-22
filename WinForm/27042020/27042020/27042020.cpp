#include <iostream>
#include <fstream>
#include <tchar.h>
#include <Windows.h>
#include <string.h> //wchar.h
#include <string> 
//wchar to console
#include <fcntl.h>
#include <io.h>
#include <cstdlib>
#include <atlbase.h>

using namespace std;
void test1()
{
	//ansi
	char yes = 'y';
	char name[10] = "Petro";
	cout << "yes  = >" << yes << endl;
	cout << "name = >" << name << endl;
	//unicode
	wchar_t no = 'n';
	wchar_t LastName[50] = L"Petenko ЯІЄЇЙ";
	wchar_t FirstName[50] = L"Hello 事奉聖禮釋義s";
	wstring LFN = TEXT("Hello 事奉聖禮釋義s");

	//universal
	TCHAR ch = 'r';
	TCHAR User[10] = _T("Текст тут");

	cout << wcslen(LastName) << endl;
	//wcscat З'єднати Unicode рядки
	//wcsncat Додайте n символів з іншого Unicode  рядка
	//wcschr Знайти перше входження символу в Unicode рядку
	//wcsrchr Знайти останє входження символу у Unicode рядку
	//wcscmp Порівняйте два Unicode рядки
	//wcsncmp Порівняйте n символів двох Unicode рядків
	//wcscpy Копіювати Unicode рядки
	//wcslen Отримати довжину Unicode  рядка
	//wcsncpy Копіювати n символів з Unicode рядка
	//wcsstr Знайти підрядок Unicode рядка
	//wcstok Розбити Unicode рядок на токени
	//wmemset Заповніть масив Unicode символів
}
void test2()
{
	wchar_t FirstName[50] = L"Hello ❤ ☭ ⌛ 🦠 事奉聖禮釋義s";
	wchar_t LastName[50] = L"Petenko Я І Є Ї Й ";
	wstring LFN = TEXT("Hello 事奉聖禮釋義s");

	_setmode(_fileno(stdout), _O_WTEXT);

	wprintf(TEXT("%s\n"), FirstName);
	wprintf(TEXT("%s\n"), LastName);


	fputws(FirstName, stdout);
	wcout << endl;
	fputws(LastName, stdout);
	wcout << endl;

	wcout << FirstName << endl;
	wcout << LastName << endl;

	_setmode(_fileno(stdout), _O_TEXT);
	cout << "Hello";

}
void test3()
{
	_setmode(_fileno(stdout), _O_WTEXT);
	_setmode(_fileno(stdin), _O_WTEXT);
	wstring LFN = TEXT("Hello 事奉聖禮釋義s");
	wcout << LFN << endl;
	wchar_t FirstName[50]{ 0 };
	wcin >> FirstName;
	wcout << FirstName << endl;

	wcin.get();
	getline(wcin, LFN);
	wcout << LFN << endl;

}

void SAVEfile()
{
	wchar_t FirstName[] = L"Hello ❤ ☭ ⌛ 🦠 事奉聖禮釋義 Piter";
	ofstream out(L"test.bin", ios::out | ios::binary);

	short bom = 0xfeff;
	out.write((char*)&bom, sizeof(bom));
	int len = wcslen(FirstName);
	out.write((char*)FirstName, len * sizeof(wchar_t));
	out.close();
}
void SAVEfileW() //not worked
{
	wchar_t FirstName[] = L"Hello ❤ ☭ ⌛ 🦠 事奉聖禮釋義 Piter";
	wofstream out(L"test.bin", ios::out | ios::binary);
	int len = wcslen(FirstName);
	out.write((wchar_t*)FirstName, len);
	out.close();
}

void Loadfile()
{
	ifstream from(L"test.bin", ios::in | ios::binary);
	if (!from) perror("not file");
	from.seekg(0, ios::end);
	int sizefile = from.tellg() / sizeof(wchar_t);
	wchar_t* text = new wchar_t[sizefile] {0};
	from.seekg(2, ios::beg);
	from.read((char*)text, sizefile * sizeof(wchar_t));
	from.close();

	_setmode(_fileno(stdout), _O_WTEXT);
	wcout << text << endl;

	delete[] text;
}

void ConvertWtoA1() {
	wchar_t text[] = L"Hello ЯІЇ ❤ ☭ ⌛ ";
	char newtext[100]{ 0 };
	int k = wcstombs(newtext, text, 6);
	if (k >= 0)
	{
		cout << "newtext" << newtext << endl;

	}
}
void ConvertAtoW1() {
	setlocale(LC_ALL, "");

	char text[20] = "Hello ЯІЇ";
	wchar_t newtext[100]{ 0 };
	int k = mbstowcs(newtext, text, 9);
	if (k >= 0)
	{
		_setmode(_fileno(stdout), _O_WTEXT);
		wcout << "newtext" << newtext << endl;

	}
}

void ConvertWtoA2() {
	wchar_t text[] = L"Hello ЯІЇ ❤ ☭ ⌛ ";

	int k = WideCharToMultiByte(CP_ACP, 0, text, -1, 0, 0, 0, 0);
	char* newtext = new char[k] { 0 };
	WideCharToMultiByte(CP_ACP, 0, text, -1, newtext, k, 0, 0);
	cout << "newtext" << newtext << endl;

}
void ConvertAtoW2() {
	setlocale(LC_ALL, "");
	char text[20] = "Hello ЯІЇ ";
	int k = MultiByteToWideChar(CP_ACP, 0, text, -1, 0, 0);
	wchar_t* newtext = new wchar_t[k] { 0 };
	MultiByteToWideChar(CP_ACP, 0, text, -1, newtext, k);
	_setmode(_fileno(stdout), _O_WTEXT);
	wcout << "newtext" << newtext << endl;
}
void ConvertAtoW3() {
	setlocale(LC_ALL, "");
	char text[20] = "Hello ЯІЇ ";
	USES_CONVERSION;
	wchar_t* newtext = A2W(text);
	_setmode(_fileno(stdout), _O_WTEXT);
	wcout << "newtext" << newtext << endl;
}
void ConvertWtoA3() {
	wchar_t text[] = L"Hello ЯІЇ ❤ ☭ ⌛ ";
	USES_CONVERSION;
	char* newtext = W2A(text);
	cout << "newtext" << newtext << endl;
}

int main()
{
	// test1();
	// test2();
	// test3();
	// SAVEfile();
	   //SAVEfileW();
	 //Loadfile();
  //   ConvertWtoA1();
   //  ConvertWtoA2();
//	ConvertAtoW1();
	//ConvertAtoW2();
	//ConvertAtoW3();
	ConvertWtoA3();
}
