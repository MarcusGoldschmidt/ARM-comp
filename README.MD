# Trabalho de metodos computacionais

## EndPoints

### Bissecção

Exemplo de estrada

Por padrão a precição é de 0.001, mas pode ser alterada colocando um valor.

**Para um ponto**

```
{
	"Funcao": "x^2 - x",
	"Ponto": {
		"A": 2,
		"B": 0
	},
	Precisao: 0.000001
}
```

**Para dois pontos**



**Para exibir a arvore montada**

Method: POST

`api/funcao-zera`

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