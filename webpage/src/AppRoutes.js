import { Counter } from "./components/Counter";
import { Edition } from "./components/Edition";
import { Home } from "./components/Home";
import { Journalist } from "./components/Journalist";
import { ListNewspapper } from "./pages/Newspapper/ListNewspapper";
import { CreateNewspapper } from "./pages/Newspapper/CreateNewspapper";
import EditNewspapper from "./pages/Newspapper/EditNewspapper";
import DeleteNewspapper from "./pages/Newspapper/DeleteNewpapper";
import { News } from "./components/News";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
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
        element: <Edition />
    },
    {
        path: '/journalist',
        element: <Journalist />
    },
    {
        path: '/news',
        element: <News />
    }
];

export default AppRoutes;
