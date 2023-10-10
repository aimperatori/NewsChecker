import React, { useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

function DeleteNewspapper() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [loading, setLoading] = useState(false);

    const handleDelete = () => {
        setLoading(true);

        // Faça uma chamada à API para excluir o newspapper com base no 'id'
        fetch(`https://localhost:7113/Newspaper/${id}`, {
            method: 'DELETE',
        })
            .then((response) => {
                if (response.status === 200 || response.status === 204) {
                    // A exclusão foi bem-sucedida, navegue de volta para a página de listagem
                    navigate('/newspapper', { replace: true }); // Use { replace: true } para substituir a entrada do histórico
                } else {
                    console.error('Erro ao excluir newspapper');
                    console.error(response);
                }
            })
            .catch((error) => {
                console.error('Erro ao excluir newspapper:', error);
            });
    };

    return (
        <div>
            <h1>Confirm Delete Newspapper</h1>
            <p>Tem certeza de que deseja excluir este newspapper?</p>
            <button onClick={handleDelete} disabled={loading}>
                {loading ? 'Excluindo...' : 'Sim, Excluir'}
            </button>
        </div>
    );
}

export default DeleteNewspapper;