M.AutoInit()


function  deletar(event){
    if (!confirm('Deseja realmente excluír')){
        event.preventDefault();
    } else {
        return true;
        
    }
    
}

function editar(dados,event){
    event.preventDefault();
    alert(dados.nome);

}