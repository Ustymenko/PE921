#include <iostream>
using namespace std;
#define begin {
#define end }
#define maxelem 100
#define pow3(x) ((x)*(x)*(x))
#define MAX(a,b) ((a)>(b)?(a):(b))
//#define sum(a,b) ((a)+(b))

template<class T>
T pow2(T x) {
	return x * x;
}

template<class Res, class T, class U>
Res sum(T a, U b) {
	return a + b;
}
template<class T>
T max(T a, T b) {
	return a > b ? a : b;
}
template<>
const char* max(const char* a, const char* b) {
	return strcmp(a,b)<0  ? b : a;
}

template<class T, class U, class Res = double>
Res sub(T a, U b) {
	return a - b;
}
//template<class T, class U>
//auto mult(T a, U b)
//{
//	return a * b;
//}
//template<class T, class U>
//auto mult(T a, U b) -> int
//{
//	return a * b;
//}

template<class T, class U>
auto mult(T a, U b) -> decltype(a* b)
{
	return a * b;
}


//double pow2(double x) 
//begin
//	return x * x;
//end
template<class T>
void showarray(T x[], size_t n) {
	for (size_t i = 0; i < n; i++)
		cout << x[i] << '\t';
	cout << '\n';
}

template<class T>
T sum(T x[], size_t n) {
	T s = 0;
	for (size_t i = 0; i < n; i++)
		s += x[i];
	return s;
}

int main()
begin
{
	double a = 10.99, c;
	int b = 20;
	c = sub(b, a);
	cout << "sub=" << c << endl; //30
}
{
	double a = 10.99, c;
	int b = 20;
	c = sub(a, b);
	cout << "sub=" << c << endl; //30
}


{
	int  a = 10;
	int res = pow2(a);
	cout << "res=" << res << endl;

	double d = 1.2;
	double resd = pow2(d);
	cout << "res=" << resd << endl;

	cout << "resA=" << pow2('a') << endl;
	//char str[] = "Ivan";
	//cout << "resA=" << pow2(str) << endl;

	//int mas[maxelem]{};
	//int mas[100; ]{};
	res = pow3(a);
	cout << "res=" << res << endl;

	resd = pow3(d);
	cout << "res=" << resd << endl;

	int  x = 5, y = 2;
	res = pow3(x + y);
	cout << "res=" << res << endl;//343

	cout << "max =" << MAX(10, 25) << endl;
	cout << "max =" << MAX(10.365, 0.225) << endl;

}
{
	int a = 10, b = 20, c;
	//Res sum(T a, U b) {
	c = sum<int, int, int>(a, b);
	cout << "sum=" << c << endl;
}
{
	double a = 10.99, b = 20.55, c;
	c = sum<double>(a, b);
	cout << "sum=" << c << endl;
}
{
	double a = 10.99, c;
	int b = 20;
	c = sum<double>(a, b);
	cout << "sum=" << c << endl; //30
}
{
	double a = 10.99, c;
	int b = 20;
	c = sum<double>(b, a);
	cout << "sum=" << c << endl; //30
}
{
	double a = 10.99, c;
	int b = 20;
	c = mult(b, a);
	cout << "mult=" << c << endl;
}
{
	double a = 10.99, c;
	int b = 20;
	c = mult(a, b);
	cout << "mult=" << c << endl;
}
{
	auto d = 10;
	auto f = 10l;
	auto g = 10ll;
	auto q = 10.5;
	auto p = 10.5f;
	cout << typeid(d).name() << '\t' << sizeof(d) << endl;
	cout << typeid(f).name() << '\t' << sizeof(f) << endl;
	cout << typeid(g).name() << '\t' << sizeof(g) << endl;
	cout << typeid(q).name() << '\t' << sizeof(q) << endl;
	cout << typeid(p).name() << '\t' << sizeof(p) << endl;

	decltype(p) w;
	cout << typeid(w).name() << '\t' << sizeof(w) << endl;







}

{
	int mas[]{ 1,3,6,9,5,9,54,-6,5 };
	showarray(mas, sizeof(mas) / sizeof(mas[0]));
	cout << sum(mas, sizeof(mas) / sizeof(mas[0])) << endl;
}
{
	double mas[]{ 1.333,3,6.9999,9,5,9,54,-6,5 };
	showarray(mas, sizeof(mas) / sizeof(mas[0]));
	cout << sum(mas, sizeof(mas) / sizeof(mas[0])) << endl;

}
{
	int a = 10, b = 20;
	cout <<"max="<< max(a, b) << endl;
}
{
	double a = 10.2696, b = 20.46;
	cout << "max=" << max(a, b) << endl;
}
{
	auto a = "Witer";
	auto b = "Petro";
	cout << "max=" << max(a, b) << endl;
}




end
