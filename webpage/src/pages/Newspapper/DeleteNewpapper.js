import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';
import ConfirmDelete from '../../components/ConfirmDelete';

function DeleteNewspapper() {
    const { id } = useParams();
    const navigate = useNavigate();

    const handleDelete = () => {
        NewsCheckerFetcher.Delete('Newspapper', id)
            .then((response) => {
                if (response.status === 200 || response.status === 204) {
                    // A exclus�o foi bem-sucedida, navegue de volta para a p�gina de listagem
                    navigate('/newspapper', { replace: true }); // Use { replace: true } para substituir a entrada do hist�rico
                } else {
                    console.error('Erro ao excluir o registro');
                    console.error(response);
                }
            })
            .catch((error) => {
                console.error('Erro ao excluir o registro:', error);
            });
    };

    return (
        <ConfirmDelete
            titulo="Confirm Delete Newspapper"
            mensagem="Are you sure you want to delete the newspapper?"
            handleDelete={handleDelete}
        />
    );
}

export default DeleteNewspapper;
