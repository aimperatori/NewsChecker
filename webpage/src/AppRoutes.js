import { Home } from "./components/Home";
import { ListJournalist } from "./pages/Journalist/ListJournalist";
import { CreateJournalist } from "./pages/Journalist/CreateJournalist";
import { ListNewspapper } from "./pages/Newspapper/ListNewspapper";
import { CreateNewspapper } from "./pages/Newspapper/CreateNewspapper";
import EditNewspapper from "./pages/Newspapper/EditNewspapper";
import DeleteNewspapper from "./pages/Newspapper/DeleteNewpapper";
import { ListNews } from "./pages/News/ListNews";
import { CreateNews } from "./pages/News/CreateNews";
import { CreateEdition } from "./pages/Edition/CreateEdition"

import { ListEdition } from "./pages/Edition/ListEdition"

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/newspapper',
        element: <ListNewspapper />
    },
    {
        path: '/newspapper/create',
        element: <CreateNewspapper />
    },
    {
        path: '/newspapper/edit/:id',
        element: <EditNewspapper />
    },
    {
        path: '/newspapper/delete/:id',
        element: <DeleteNewspapper />
    },
    {
        path: '/edition',
        element: <ListEdition />
    },
    {
        path: '/edition/create',
        element: <CreateEdition />
    },
    {
        path: '/journalist',
        element: <ListJournalist />
    },
    {
        path: '/journalist/create',
        element: <CreateJournalist />
    },
    {
        path: '/news',
        element: <ListNews />
    },
    {
        path: '/news/create',
        element: <CreateNews />
    }
];

export default AppRoutes;
