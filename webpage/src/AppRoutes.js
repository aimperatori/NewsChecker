import { Home } from "./components/Home";
import { ListJournalist } from "./pages/Journalist/ListJournalist";
import { CreateJournalist } from "./pages/Journalist/CreateJournalist";
import EditJournalist from "./pages/Journalist/EditJournalist";
import DeleteJournalist from "./pages/Journalist/DeleteJournalist";
import { ListNewspaper } from "./pages/Newspaper/ListNewspaper";
import { CreateNewspaper } from "./pages/Newspaper/CreateNewspaper";
import EditNewspaper from "./pages/Newspaper/EditNewspaper";
import DeleteNewspaper from "./pages/Newspaper/DeleteNewpaper";
import { ListNews } from "./pages/News/ListNews";
import { CreateNews } from "./pages/News/CreateNews";
import EditNews from "./pages/News/EditNews";
import DeleteNews from "./pages/News/DeleteNews";
import { CreateEdition } from "./pages/Edition/CreateEdition"
import { ListEdition } from "./pages/Edition/ListEdition"
import EditEdition from "./pages/Edition/EditEdition"
import DeleteEdition from "./pages/Edition/DeleteEdition"

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/newspaper',
        element: <ListNewspaper />
    },
    {
        path: '/newspaper/create',
        element: <CreateNewspaper />
    },
    {
        path: '/newspaper/edit/:id',
        element: <EditNewspaper />
    },
    {
        path: '/newspaper/delete/:id',
        element: <DeleteNewspaper />
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
        path: '/edition/delete/:id',
        element: <DeleteEdition />
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
        path: '/journalist/delete/:id',
        element: <DeleteJournalist />
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
    },
    {
        path: '/news/delete/:id',
        element: <DeleteNews />
    }
];

export default AppRoutes;
