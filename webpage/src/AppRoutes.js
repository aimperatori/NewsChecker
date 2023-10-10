import { Counter } from "./components/Counter";
import { Edition } from "./components/Edition";
import { Home } from "./components/Home";
import { Journalist } from "./components/Journalist";
import { NewsPapper } from "./components/Newspapper";
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
        element: <NewsPapper />
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
