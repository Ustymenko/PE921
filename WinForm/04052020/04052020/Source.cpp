#include<Windows.h>
#include<tchar.h>
#define static1 10001
#define static2 10002
#define static3 10003
//buttons
#define button1 20001
#define button2 20002
HWND stat1;
void create_static(HWND hWnd) {
	stat1 = CreateWindow(L"static", L"Привіт", WS_VISIBLE | WS_CHILD | SS_SIMPLE,
		10, 10, 100, 20, hWnd, (HMENU)static1, 0, 0);
	CreateWindow(L"static", L"ItStep", WS_VISIBLE | WS_CHILD | SS_SIMPLE,
		120, 10, 100, 20, hWnd, (HMENU)static2, 0, 0);
	/*	CreateWindow(L"static", L"Привіт", WS_VISIBLE | WS_CHILD | SS_BLACKRECT,
			10, 10, 100, 20, hWnd, (HMENU)static1, 0, 0);
		CreateWindow(L"static", L"Привіт", WS_VISIBLE | WS_CHILD | SS_BLACKFRAME,
			10, 10, 100, 20, hWnd, (HMENU)static1, 0, 0);*/
	HWND hPic = CreateWindow(L"static", 0, WS_VISIBLE | WS_CHILD | SS_BITMAP,
		220, 10, 0, 0, hWnd, (HMENU)static3, 0, 0);
	HANDLE himg = LoadImage(0, L"butt1.bmp", IMAGE_BITMAP, 0, 0,
		LR_DEFAULTCOLOR | LR_DEFAULTSIZE | LR_LOADFROMFILE);
	SendMessage(hPic, STM_SETIMAGE, IMAGE_BITMAP, (LPARAM)himg);

	//SetWindowText(stat1, L"Hello");
		//SetDlgItemText(hWnd, static2, L"Житомир");
		//SendMessage(stat1, WM_SETTEXT, 0, (LPARAM)L"Hello");

}

void create_buttons(HWND hWnd) {
	CreateWindow(L"button", L"Yes", WS_VISIBLE | WS_CHILD | BS_PUSHBUTTON | BS_NOTIFY,
		10, 40, 50, 30, hWnd, (HMENU)button1, 0, 0);
	CreateWindow(L"button", L"No", WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		70, 40, 50, 30, hWnd, (HMENU)button2, 0, 0);

	CreateWindow(L"button", L"OK", WS_VISIBLE | WS_CHILD | BS_AUTOCHECKBOX,
		10, 70, 50, 30, hWnd, (HMENU)20003, 0, 0);

	CreateWindow(L"button", L"OK", WS_VISIBLE | WS_CHILD | BS_AUTORADIOBUTTON,
		70, 70, 50, 30, hWnd, (HMENU)20004, 0, 0);
	CreateWindow(L"button", L"No", WS_VISIBLE | WS_CHILD | BS_AUTORADIOBUTTON,
		130, 70, 50, 30, hWnd, (HMENU)20005, 0, 0);

	HWND hPic = CreateWindow(L"button", 0, WS_VISIBLE | WS_CHILD | BS_BITMAP,
			10, 150, 70, 70, hWnd, (HMENU)20006, 0, 0);
	HANDLE himg = LoadImage(0, L"butt1.bmp", IMAGE_BITMAP, 0, 0,
		LR_DEFAULTCOLOR | LR_DEFAULTSIZE | LR_LOADFROMFILE);
	SendMessage(hPic, BM_SETIMAGE, IMAGE_BITMAP, (LPARAM)himg);
}
LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam)
{
	switch (uMessage)
	{
	case WM_CTLCOLORSTATIC: {
		//if (GetDlgItem(hWnd, static1)== (HWND)lParam){
		if (stat1 == (HWND)lParam) {
			HDC hdc = (HDC)wParam;
			SetTextColor(hdc, RGB(255, 0, 0));
			return (LRESULT)GetStockObject(NULL_BRUSH);
		}
	}break;
	case WM_CREATE: {
		create_static(hWnd);
		create_buttons(hWnd);


	} break;
	case WM_MOUSEMOVE: {
		wchar_t buf[100]{ 0 };
		int x = LOWORD(lParam);
		int y = HIWORD(lParam);
		swprintf_s(buf, TEXT("x=%4d, y = %4d"), x, y);
		SetWindowText(hWnd, buf);

		

		//GetClientRect
		RECT rectButtonYes;
		GetWindowRect(GetDlgItem(hWnd, button1),&rectButtonYes);
		int width = rectButtonYes.right - rectButtonYes.left;
		int height = rectButtonYes.bottom - rectButtonYes.top;

		POINT p{ x,y };
		//GetCursorPos(&p);
		p.x += 5;
		p.y += 5;
		if (ChildWindowFromPoint(hWnd,p) == GetDlgItem(hWnd, button1)) {
			//SetWindowText(GetDlgItem(hWnd, button1), buf);
			MoveWindow(GetDlgItem(hWnd, button1), rand()%400, rand() % 400, width, height, 1);
		}


	//	MoveWindow(GetDlgItem(hWnd, button1),150,200, width, height, 1);

	}   break;
	case WM_LBUTTONDOWN: {
	}break;
	case WM_RBUTTONDOWN: {
	}break;
	case WM_MBUTTONDOWN:
		break;
	case WM_COMMAND: {
		switch (LOWORD(wParam))
		{
			case button1:
				if (HIWORD(wParam) == BN_CLICKED)
					MessageBox(hWnd, L"click on the button1", L"info", 0);
				if (HIWORD(wParam) == BN_SETFOCUS)
					MessageBox(hWnd, L"BN_SETFOCUS on the button1", L"info", 0);
				break;
		}
	}
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

class WinClass
{
public:
	WinClass(HINSTANCE hInst, LPCWCH szClassWindow, WNDPROC wProc);
	LPCWCH GetName() {
		return wcl.lpszClassName;
	}
private:
	WNDCLASSEX wcl;
	void Register() {
		if (!RegisterClassEx(&wcl)) {
			MessageBox(0, TEXT("Не можу зареєструвати клас"), TEXT("Помилка"), MB_OK | MB_ICONERROR);
			exit(1);
		}
	}
};
WinClass::WinClass(HINSTANCE hInst, LPCWCH szClassWindow, WNDPROC wProc)
{
	wcl = { 0 };
	wcl.cbSize = sizeof(wcl);
	//wcl.style = CS_HREDRAW | CS_VREDRAW;
	wcl.lpfnWndProc = wProc;
	wcl.lpszClassName = szClassWindow;
	//wcl.cbClsExtra = 0;
	//wcl.cbWndExtra = 0;
	wcl.hInstance = hInst;
	wcl.hIcon = LoadIcon(NULL, IDI_ASTERISK);
	wcl.hIconSm = LoadIcon(NULL, IDI_ASTERISK);
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcl.hbrBackground = (HBRUSH)COLOR_APPWORKSPACE;//;  //GetStockObject(WHITE_BRUSH);
	//wcl.lpszMenuName = NULL;

	Register();
}


INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow) {

	WinClass CW(hInst, TEXT("Моя перша програма"), WindowProc);
	HWND hWnd = CreateWindowEx(0, CW.GetName(), TEXT("Перша програма"),
		WS_OVERLAPPEDWINDOW | WS_VISIBLE,
		100, 200, 640, 480, NULL, NULL, hInst, NULL);
	if (!hWnd) {
		MessageBox(NULL, L"Не вийшло створити вікно Main!", L"Error", MB_OK);
		return 2;
	}
	MSG lpMsg = { 0 };
	while (GetMessage(&lpMsg, NULL, 0, 0)) {
		if (!IsDialogMessage(hWnd, &lpMsg))
		{
			TranslateMessage(&lpMsg);
			DispatchMessage(&lpMsg);
		}
	}
	return lpMsg.wParam;
}