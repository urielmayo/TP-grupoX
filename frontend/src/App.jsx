import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Signup from "./pages/Signup";
import { userLoader } from "./utils/auth";
import { loginFormAction } from "./pages/Login";
import LogoutAction from "./pages/Logout";
import ContributionList, {
  contributionsLoader,
} from "./pages/ContributionList";
import NewContribution from "./pages/NewContribution";
import ErrorPage from "./pages/Error";
import RewardsList, { rewardsLoader } from "./pages/RewardsList";

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    id: "root",
    loader: userLoader,
    errorElement: <ErrorPage />,
    children: [
      { index: true, element: <Home /> },
      {
        path: "users",
        children: [
          { path: "login", element: <Login />, action: loginFormAction },
          { path: "signup", element: <Signup /> },
          { path: "logout", action: LogoutAction },
          {
            path: "contributions",
            children: [
              {
                index: true,
                element: <ContributionList />,
                loader: contributionsLoader,
              },
              { path: "new", element: <NewContribution /> },
            ],
          },
        ],
      },
      {
        path: "rewards",
        children: [
          { index: true, element: <RewardsList />, loader: rewardsLoader },
          { path: ":rewardId", element: <p>Premio</p> },
        ],
      },
    ],
  },
]);

export default function App() {
  return <RouterProvider router={router} />;
}
