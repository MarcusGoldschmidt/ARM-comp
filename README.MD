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

Pode ser usado para testar os metodos de interpolação.

**Para exibir a arvore criada para as equações montada**

Suporte para prioridade de parênteses.

Notação cientifica suportada:

```
{
	"Funcao": "5E-15",
}
```

Valor para e = 2.71828182845905

Valor para P = 3.14159265358979

```
{
	"Funcao": "e * P",
}
```

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

**Calculando usando posição falsa**

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
	"Pontos": [
		{
			"x": 0,
			"y": 5
		},
		{
			"x": 0,
			"y": 5
		},
	]
}
```

**Calculando usando Forma de newton**

Method: POST

`api/interpolacao/newton`

```
{
	"Pontos": [
		{
			"x": 1,
			"y": 1
		},
		{
			"x": 2,
			"y": 7
		},
		{
			"x": 3,
			"y": 10
		}
	]
}
```

**Calculando usando Forma Linear**

Method: POST

`api/interpolacao/linear`

```
{
	"Pontos": [
		{
			"x": 1,
			"y": 1
		},
		{
			"x": 2,
			"y": 7
		},
		{
			"x": 3,
			"y": 10
		}
	]
}
```

**Calculando usando Forma Trignometrica**

Method: POST

`api/interpolacao/trignometrica`

```
{
	"Pontos": [
		{
			"x": 1,
			"y": 1
		},
		{
			"x": 2,
			"y": 7
		},
		{
			"x": 3,
			"y": 10
		}
	]
}
```

## Intervalo de confiança

**Usando tabela normal**

Method: POST

`api/confianca/normal`

```
{
	"IntervaloDeConfianca": 95.2,
	"Media": 1.69,
	"DesvioPadrao": 5,
	"QuantidadeElementos": 10
}
```

**Usando tabela tstudent**

Method: POST

`api/confianca/tstudent`

```
{
	"IntervaloDeConfianca": 95.2,
	"Media": 1.69,
	"DesvioPadrao": 5,
	"QuantidadeElementos": 10
}
```

Method: POST

`api/proporcao/populacional`

```
{
	"IntervaloDeConfianca": 95.2,
	"DesvioPadrao": 5,
	"QuantidadeElementos": 10,
	"CasosDeSucesso": 5
}
```

## Coeficiente de Correlação

Todos os metodos usando a mesma estrutura

```
{
	"Pontos": [
		{
			"x": 1,
			"y": 1
		},
		{
			"x": 2,
			"y": 7
		},
		{
			"x": 3,
			"y": 10
		}
	]
}
```

**Coeficiente de Correlação de Person**

Method: POST

`api/correlacao/person`

**Coeficiente de Correlação de Spearman**

Method: POST

`api/correlacao/spearman`

**Coeficiente de Correlação de Kendall**

Method: POST

`api/correlacao/kendall`