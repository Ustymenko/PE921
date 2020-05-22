#include <Windows.h>
//#include <stdio.h>

class WinClass
{
public:
	WinClass(LPCWSTR name, WNDPROC WndProc, HINSTANCE Instance);
	LPCWSTR GetName() { return wc.lpszClassName; }
private:
	LPCWSTR	Name;
	WNDCLASSEX wc{ 0 };
	void Register() {
		if (!RegisterClassEx(&wc)) {
			MessageBox(0, TEXT("Не можу зареєструвати клас"), TEXT("Помилка"), MB_OK | MB_ICONERROR);
			exit(1);
		}
	}

};

WinClass::WinClass(LPCWSTR name, WNDPROC WndProc, HINSTANCE Instance)
{
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WndProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = Instance;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = name;
	wc.hIconSm = NULL;
	Register();

}

LRESULT CALLBACK  WindowProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {
	switch (message) {
		case WM_LBUTTONDOWN:
		{
			MessageBox(0, TEXT("WM_LBUTTONDOWN"), TEXT("Мишка"), MB_OK | MB_ICONINFORMATION);

		} break;
		default:
			DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInstance,
	LPSTR lpCmdLine, INT nCmdShow)
{
	TCHAR  szClassWindow[] = TEXT("Моя перша програма");
	HWND hWnd;
	MSG lpMsg;
	WNDCLASSEX wcl;
	/* 1. Определение класса окна */
	wcl.cbSize = sizeof(wcl);
	wcl.style = CS_HREDRAW | CS_VREDRAW;
	wcl.lpfnWndProc = WindowProc;
	wcl.cbClsExtra = 0;
	wcl.cbWndExtra = 0;
	wcl.hInstance = hInst;
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wcl.lpszMenuName = NULL;
	wcl.lpszClassName = szClassWindow;
	wcl.hIconSm = NULL;
	/* 2. Регистрация класса окна */
	if (!RegisterClassEx(&wcl))
		return 0;
	/* 3. Создание окна */
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("My first window"), WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL
	);
	/* 4. Отображение окна */
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	/* 5. Запуск цикла обработки сooбщений */
	while (GetMessage(&lpMsg, NULL, 0, 0)) {
		TranslateMessage(&lpMsg);
		DispatchMessage(&lpMsg);
	}
	return lpMsg.wParam;


}