import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';
import ConfirmDelete from '../../components/ConfirmDelete';

function DeleteJournalist() {
    const { id } = useParams();
    const navigate = useNavigate();

    const handleDelete = () => {
        NewsCheckerFetcher.Delete('journalist', id)
            .then((response) => {
                if (response.status === 200 || response.status === 204) {
                    // A exclusão foi bem-sucedida, navegue de volta para a página de listagem
                    navigate('/journalist', { replace: true }); // Use { replace: true } para substituir a entrada do histórico
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
            titulo="Confirm Delete Journalist"
            mensagem="Are you sure you want to delete the journalist?"
            handleDelete={handleDelete}
        />
    );
}

export default DeleteJournalist;
