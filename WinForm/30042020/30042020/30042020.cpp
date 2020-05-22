#include<Windows.h>
#include<tchar.h>


BOOL CALLBACK EnumProcH(HWND hWnd, LPARAM lParam) {
	ShowWindow(hWnd, SW_MINIMIZE);
	return true;
}
BOOL CALLBACK EnumProcSH(HWND hWnd, LPARAM lParam) {
	ShowWindow(hWnd, SW_RESTORE);
	return true;
}
LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam)
{
	switch (uMessage)
	{
	case WM_MOUSEMOVE: {
		wchar_t buf[100]{ 0 };
		int x = LOWORD(lParam);
		int y = HIWORD(lParam);
		swprintf_s(buf, TEXT("x=%4d, y = %4d"), x, y);
		SetWindowText(hWnd, buf);
	}   break;
	case WM_LBUTTONDOWN: {
		//MessageBox(0, TEXT("Click"), TEXT("Info"), MB_OK | MB_ICONINFORMATION);
		HWND hcalc = FindWindow(TEXT("CalcFrame"), 0);
		wchar_t buf[100]{ 0 };
		GetWindowText(hcalc,buf,100);
		wcscat(buf, L"1");
		SetWindowText(hcalc, buf);
		//EnumChildWindows(hcalc, EnumProcSH, 0);
		//InvalidateRect(hcalc,0,0);
		//UpdateWindow(hcalc);
	}break;
	case WM_RBUTTONDOWN: {
		//	SetWindowText(hWnd, TEXT("Hello"));
	//	HWND hcalc =FindWindow(0, TEXT("Калькулятор"));
		HWND hcalc =FindWindow( TEXT("CalcFrame"),0);
		EnumChildWindows(hcalc, EnumProcH, 0);
		InvalidateRect(hcalc, 0, 0);
		UpdateWindow(hcalc);
		//SetWindowText(hcalc, TEXT("Hello It Step"));
		//SetWindowText((HWND)0x007F0F7A, TEXT("H"));

		//SendMessage(hcalc, WM_CLOSE, 0, 0);

	}break;
	case WM_MBUTTONDOWN:	
		break;
	case WM_KEYDOWN: {
		switch (LOWORD(wParam))
		{
		case VK_RIGHT:
			MoveWindow(hWnd, 300, 200, 640, 480, 1);
		break;
		case VK_LEFT:
			MoveWindow(hWnd, 100, 200, 640, 480, 1);
			break;
		case VK_RETURN://13
			MessageBox(0, TEXT("ентер"), TEXT("Info"), MB_OK | MB_ICONINFORMATION);
			break;
		case 32: 
			MessageBox(0, TEXT("пробіл"), TEXT("Info"), MB_OK | MB_ICONINFORMATION);
			break;
		default:
			break;
		}


	
	
	}break;



	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMessage, wParam, lParam);
	}
	return 0;
}

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow) {
	
TCHAR szClassWindow[] = TEXT("Каркасное приложение");  /* Имя класса окна */
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
	HWND hWnd;
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("My first window"),
		WS_OVERLAPPEDWINDOW, 100, 200, 640,
		480, NULL, NULL, hInst, NULL	);
	if (!hWnd) {
		MessageBox(NULL, L"Не вийшло створити вікно Main!", L"Error", MB_OK);
		return 2;
	}

	/* 4. Отображение окна */
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	/* 5. Запуск цикла обработки сooбщений */
	MSG lpMsg;
	while (GetMessage(&lpMsg, NULL, 0, 0)) {
		TranslateMessage(&lpMsg);
		DispatchMessage(&lpMsg);
	}
	return lpMsg.wParam;
}
