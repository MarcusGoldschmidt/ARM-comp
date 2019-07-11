# Trabalho de metodos computacionais

## Executando o projeto

Por padrão vem na porta 5001

```
dotnet run
```

## Testes unitários

```
dotnet test
```

## Bissecção

**Calculando função genérica**

Method: POST

`api/math`

```
{
	"Funcao": "x^2 - x",
	"X": 5
}
```

Pode ser usado para testar os metodos de interpolação

**Para exibir a arvore criada para as equações montada**

Suporte para prioridade de parênteses

Funções suportadas:

```
sen(...)
cos(...)
tan(...)
arcsen(...)
arccos(...)
arctan(...)
ln(...)
sqrt(...)
```

Method: POST

`api/funcao-zera`

```
{
	"Funcao": "x^2 - x",
}
```

```
{
	"Funcao": "sen(x + x) + x",
}
```

Testando prioridade de operadores

```
{
	"Funcao": "x + x * x",
}
```

**Calculando usando bissecao**

Method: POST

`api/funcao-zera/bissecao`

```
{
	"Funcao": "x^2 - x",
	"Ponto": {
		"A": 2,
		"B": 0
	},
	"Precisao": 0.000001
}
```

**Calculando usando posição false**

Method: POST

`api/funcao-zera/posicao-falsa`

```
{
	"Funcao": "x^2 - x",
	"Ponto": {
		"A": 2,
		"B": 0
	},
	"Precisao": 0.001
}
```

**Calculando usando Newton Raphson**

Method: POST

`api/funcao-zera/newton`

```
{
	"Funcao": "x^2 - x",
	"DerivadaFuncao": "2 * x",
	"X": 5
	"Precisao": 0.000001
}
```

**Calculando usando Newton Raphson com derivada simulada**

Method: POST

`api/funcao-zera/newton/derivada`

```
{
	"Funcao": "x^2 - x",
	"X": 5
	"X2": 7
	"Precisao": 0.01
}
```

## Interpolação

**Calculando usando Lagrange**

Method: POST

`api/interpolacao/lagrange`

```
{
	Pontos: [
	    {x,y},
	    {x,y}
	]
}
```