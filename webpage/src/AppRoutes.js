import { Home } from "./components/Home";
import { ListJournalist } from "./pages/Journalist/ListJournalist";
import { CreateJournalist } from "./pages/Journalist/CreateJournalist";
import EditJournalist from "./pages/Journalist/EditJournalist";
import { ListNewspapper } from "./pages/Newspapper/ListNewspapper";
import { CreateNewspapper } from "./pages/Newspapper/CreateNewspapper";
import EditNewspapper from "./pages/Newspapper/EditNewspapper";
import DeleteNewspapper from "./pages/Newspapper/DeleteNewpapper";
import { ListNews } from "./pages/News/ListNews";
import { CreateNews } from "./pages/News/CreateNews";
import EditNews from "./pages/News/EditNews";
import { CreateEdition } from "./pages/Edition/CreateEdition"
import { ListEdition } from "./pages/Edition/ListEdition"
import EditEdition from "./pages/Edition/EditEdition"

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
        path: '/edition/edit/:id',
        element: <EditEdition />
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
        path: '/journalist/edit/:id',
        element: <EditJournalist />
    },
    {
        path: '/news',
        element: <ListNews />
    },
    {
        path: '/news/create',
        element: <CreateNews />
    },
    {
        path: '/news/edit/:id',
        element: <EditNews />
    }
];

export default AppRoutes;
