/*

La sandía (Codeforces 4A)
(¿Se puede partir una sandía de modo que ambos trozos sean enteros
y pares?)

Entrada de ejemplo 1
4

Salida para la entrada de ejemplo 1
YES

Entrada de ejemplo 2
3

Salida para la entrada de ejemplo 2
NO

*/

#include <iostream>

using namespace std;

int main()
{
    int peso;
    cin >> peso;
    
    if (( peso > 2 ) && ( peso % 2 == 0 ))
        cout << "YES" << endl;
    else
        cout << "NO" << endl;
        
    return 0;
}
