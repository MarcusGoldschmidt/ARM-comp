# Trabalho de metodos computacionais

## EndPoints

### Bissecção

Exemplo de estrada

**Para um ponto**

```
{
	"funcao": "x^2 - x",
	"ponto": {
		"A": 2,
		"B": 0
	}
}
```

**Para dois pontos**

```
{
	"funcao": "x^2 - x",
	"ponto": {
		"A": 2,
		"B": 0
	},
	"ponto2": {
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
