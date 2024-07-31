##  api-lanchonete

## O problema:

Há uma lanchonete de bairro que está expandindo devido seu grande sucesso. Porém, com a expansão e sem um sistema de controle de pedidos, o atendimento aos clientes pode ser caótico e confuso. 
Por exemplo, imagine que um cliente faça um pedido complexo, como um hambúrguer personalizado com ingredientes específicos, acompanhado de batatas fritas e uma bebida. 
O atendente pode anotar o pedido em um papel e entregá-lo à cozinha, mas não há garantia de que o pedido será preparado corretamente. 

Sem um sistema de controle de pedidos, pode haver confusão entre os atendentes e a cozinha, resultando em atrasos na preparação e entrega dos pedidos. Os pedidos podem ser perdidos, mal interpretados ou esquecidos, levando à insatisfação dos clientes e a perda de negócios. 
Em resumo, um sistema de controle de pedidos é essencial para garantir que a lanchonete possa atender os clientes de maneira eficiente, gerenciando seus pedidos e estoques de forma adequada. 
Sem ele, expandir a lanchonete pode acabar não dando certo, resultando em clientes insatisfeitos e impactando os negócios de forma negativa. 

Para solucionar o problema, a lanchonete irá investir em um sistema de autoatendimento de fast food, que é composto por uma série de dispositivos e interfaces que permitem aos clientes selecionar e fazer pedidos sem precisar interagir com um atendente.

## Para execucao da aplicacao:
 0-Clonar repo localmente <br>
 1-Iniciar Docker Desktop (habilitando a opcao do kubernetes enable)  <br>
 2-Abrir o terminal  <br>
 3-Ir ate a raiz do repositório da aplicacao  <br>
 4-Ir para diretorio do kubernetes pelo terminal  <br>
 5-digite kubectl create ns api-lanchonete-jordan  <br>
 6-kubectl apply -f ./ -n api-lanchonete-jordan (vai aplicar os yamls disponiveis na pasta)  <br>
	*OBS: Aguarde o pod de banco de dados (sql server) subir pois deve levar alguns minutos para fazer o download da imagem.  <br>
 
  Apos Pod da aplicacao e do banco de dados estarem disponiveis, acesse:  <br>
  http://localhost:30007/swagger/index.html   <br>
  
> Apenas para conhecimento: O script inicial da aplicacao está na pasta /var/tmp dentro do container do servico SQL server. Foi criado o script inicial e copiado
 para dentro da pasta /var/tmp no container do sql server e apartir disso criei um novo container sql server e publiquei em meu repo no docker hub.
 O script será executado automaticamente

## Acesso aos dados
1- Acesse uma instancia do Sql Server Management Studio ou outro client semelhante:
# Credenciais
>Host: localhost,30008 <br>
>Usuário: rmjordan <br>
>Senha: fiap@2025 <br>
>Nome do Banco: Lanchonete  <br>

## Arquitetura
![Arquitetura drawio](https://github.com/user-attachments/assets/ced8a56e-eca8-4fdb-98f3-1806a5a615c6)


Link do youtube com arquitetura: https://youtu.be/etsxha6GCgA
