import axios from 'axios';

export const task = async (filter) => {
    try {
        const response = await axios.get('https://localhost:7105/tasks/sort', {
            params: {
                sort: filter?.sortOrder,
            }
        });

        return response.data || []; // Если данных нет, возвращаем пустой массив

    } catch (error) {
        console.error("Error fetching tasks:", error);
        return []; // В случае ошибки возвращаем пустой массив
    }
}



export const createTask = async (task) => {
    try {
        const response = await axios.post('https://localhost:7105/tasks', task);

        return response.status

    } catch (error) {
        console.error("Error fetching tasks:", error);
    }
}
