# Trabalho de metodos computacionais

## EndPoints

### Bissecção

Exemplo de estrada

**Para um ponto**

```
{
	"Funcao": "x^2 - x",
	"Ponto": {
		"A": 2,
		"B": 0
	}
}
```

**Para dois pontos**

```
{
	"Funcao": "x^2 - x",
	"Ponto": {
		"A": 2,
		"B": 0
	},
	"Ponto2": {
		"A": 2,
		"B": 0
	}
}
```

**Para exibir a arvore montada**

Method: POST

`api/funcao-zera`

**Calculando usando bissecao**

Method: POST

`api/funcao-zera/bissecao`
