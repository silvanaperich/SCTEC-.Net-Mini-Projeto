# AutoCheck.ConsoleApp #

>Aplicação desenvolvida em C# .Net para mini-projeto avaliativo do curso **Desenvolvedor Back-End Net T1** do SCTEC.

## Objetivo do sistema ##

Desenvolvido para automatizar o procedimento de **vistoria técnica** aplicado ao setor automotivo (concessionárias, locadoras de veículos e seguradoras). É um processo indispensável antes de comprar um carro usado para revenda ou aceitá-lo como entrada na troca por um zero-quilômetro, a empresa precisa verificar rigorosamente se o veículo cumpre os requisitos mínimos de segurança e conservação mecânica.

A vistoria consiste, para cada veículo (Carro, Moto ou Caminhão), responder um checklist pré-definido com o status "Bom", "Regular" ou "Ruim"; a partir da situação dos itens do checklist será aplicada um processo de avaliação retornando a aprovação ou não do veículo.

Solução dispõe de emissão de relatório apresentando os dados do veículo, checklist da vistoria e avaliação final.

## Como Executar o Projeto ##

### Pré-requisitos
- **.NET SDK 10.0** (ou superior) instalado na máquina.
- Terminal (PowerShell, Windows Terminal ou Bash).

### Passo a Passo
1. Clone este repositório:
   ```bash
   git clone [https://github.com/silvanaperich/SCTEC-.Net-Mini-Projeto.git](https://github.com/silvanaperich/SCTEC-.Net-Mini-Projeto.git)

2. Navegue até a pasta do projeto:
    ```bash 
    cd ./src/AutoCheck.ConsoleApp
    ```
3. Execute a aplicação:
    ```bash 
    dotnet run
    ```

## Regra do Cálculo de Aprovação do Veículo ##

Conforme o status de cada item do checklist, será atribuída um pontuação:
- Bom: 10 pontos;
- Regular: 5 pontos;
- Ruim: 0 pontos.

A soma dos pontos de todos os itens do checklist (pontos obtidos) será dividida pelo valor que representa a pontuação máxima a ser obtida (itens do checklist x 10), obtendo o percentual de aprovação conforme cálculo abaixo:

 $\text{Percentual} = \left(\frac{\text{Pontos Obtidos}}{\text{Pontos Máximos}} \times 100\right)$

 **Faixas de aprovação:**
  - 90% a 100%: Aprovado com Excelência
  - 60% a 89%: Aprovado com Apontamentos
  - 0% a 59%: Reprovado

## Critérios de Priorização das Recomendações de Manutenção ##

- **Prioridade 1 (Vermelho):** Itens com status "Ruim" exigem reparo/troca imediata antes da liberação do veículo.
- **Prioridade 2 (Amarelo):** Itens com status "Regular" entram como recomendação de revisão preventiva.

## Conceitos do módulo 1 ##

- Utilização das ferramentas apresentadas: .Net, VsCode;
- Lógica de programação;
- Tipos de dados: string, int, double, bool;
- Manipulação de coleções: List<T>;
- Estruturas de decisão: if-else, switch;
- Laços de repetições: while, do-while, foreach;
- Programação Orientada a Objetos: classes, atributos, propriedades, construtores, encapsulamento, uso do this, herança, sobrescrita e polimorfismo;
- Versionamento no Git/GitHub.

## Cliente-Servidor ##

A arquitetura cliente-servidor divide a aplicação em duas partes: 
- Cliente: interface onde possui as telas e captura dos dados.
- Servidor: onde ocorre o processamento/gerenciamento dos dados, aplicação das regras de negócio, cálculos.

Neste projeto, que é uma aplicação de execução única/monolítica (executada localmente), pode-se considerar que a apresentação do menu (Menu.cs) e a entradas dos dados dos veículos e vistoria são parte da camada Cliente; o processamento (MotoVistoria.cs) e definições do modelo das classes (Carro.cs, Moto.cs, Caminhao.cs) caracterizam a parte Servidor. 

## Vídeo de apresentação ##

[a gravar]

## Tecnologias Utilizadas ##

Linguagem: C# (.NET Core)  
IDE: Visual Studio Code / Visual Studio 2022  
Versionamento: Git e GitHub

---
Feito por Silvana Aparecida Perich