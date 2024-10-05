async function obterCarrinho() {
    try {
        const token = localStorage.getItem("token");
        const response = await fetch('http://localhost:5160/api/Carrinho/1', {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            }
        });

        const responseJson = await response.json();
        if (response.ok) {
            await criarTabela(responseJson);
        } else {
            console.log("Erro ao obter o carrinho.");
        }
    } catch (error) {
        console.log("Erro na solicitação à API: " + error);
    }
}

obterCarrinho();

async function criarTabela(data) {
    const table = document.getElementById("tabelaProdutos");
    let html = `
        <thead>
            <tr>
                <th>Produto</th>
                <th class="text-center">Quantidade</th>
                <th class="text-center">Preço</th>
                <th class="text-center">Subtotal</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
    `

    data.itens.forEach(item => {
        html += `
            <tr>
                <td>${item.produto}</td>
                <td class="text-center">
                    <input type="text" value="${item.quantidade}" id="quantity-${item.id}" name="quantity-${item.id}">
                    <button class="btn btn-warning" onclick="atualizarItem(${item.id})">Atualizar</button>
                </td>
                <td class="text-center">${item.precoUnitario}</td>
                <td class="text-center">${item.precoTotal}</td>
                <td>
                    <button class="btn btn-danger" onclick="removerItem(${item.id})">Remover</button>
                </td>
            </tr>
        `
    });

    html += `
        </tbody>
            <tfoot>
                <tr>
                    <td colspan="3"></td>
                    <td class="text-end" colspan=1">Quantidade total: </td>
                    <td class="text-start" colspan=1">${data.totalItens}</td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                    <td class="text-end" colspan="1">Valor total: </td>
                    <td class="text-start" colspan=1">R$${data.totalValor} </td>
                </tr>
            </>
        </table>`;

    table.innerHTML = html;
}

document.getElementById("adicionarItem").addEventListener("click", async () => {
    const produto = document.getElementById("produto").value;
    const quantidade = document.getElementById("quantidade").value;
    const precoUnitario = document.getElementById("precoUnitario").value;

    try {
        const response = await fetch('http://localhost:5160/api/Carrinho/1', {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                produto,
                quantidade,
                precoUnitario
            })
        });
        const responseJson = await response.json();
        console.log(responseJson);
        if (response.ok) {
            appendAlert(responseJson.mensagem, 'success')
            await obterCarrinho();
        } else {
            appendAlert(responseJson.mensagem, 'danger')
            console.log("Erro ao adicionar o item.");
        }
    } catch (error) {
        console.log("Erro na solicitação à API: " + error);
    }
});

const appendAlert = (message, type) => {
    const alert = document.getElementById('liveAlertPlaceholder')
    const wrapper = document.createElement('div')
    wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
        '</div>'
    ].join('')

    alert.innerHTML = wrapper.innerHTML
}

const removerItem = async (id) => {
    try {
        const response = await fetch(`http://localhost:5160/api/Carrinho/${id}`, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
            }
        });
        const responseJson = await response.json();
        console.log(responseJson);
        if (response.ok) {
            appendAlert(responseJson.mensagem, 'warning')
            await obterCarrinho();
        } else {
            appendAlert(responseJson.mensagem, 'danger')
            console.log("Erro ao remover o item.");
        }
    } catch (error) {
        console.log("Erro na solicitação à API: " + error);
    }
}

const atualizarItem = async (id) => {
    const quantidade = document.getElementById(`quantity-${id}`).value;
    try {
        const response = await fetch(`http://localhost:5160/api/Carrinho/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                quantidade
            })
        });
        const responseJson = await response.json();
        if (response.ok) {
            appendAlert(responseJson.mensagem, 'success');
            await obterCarrinho();
        } else {
            appendAlert(responseJson.mensagem, 'danger');
            await obterCarrinho();
        }
    } catch (error) {
        console.log("Erro na solicitação à API: " + error);
    }
}