import { Select } from "@chakra-ui/react";

export default function SelectFilters({ filters, setFilters }) {
    const handleSortChange = (e) => {
        setFilters({
            ...filters, // сохраняем текущее состояние фильтров
            sortOrder: e.target.value // обновляем только `sortOrder`
        });
    };

    return (
        <div className='flex flex-col gap-5'>
            <Select value={filters.sortOrder} onChange={handleSortChange}> 
                <option value='desc'> New </option>
                <option value='asc'> Old </option>
            </Select>
        </div>
    );
}
