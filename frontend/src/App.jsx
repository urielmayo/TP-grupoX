import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import HomePage, { loader as fridgesLoader } from "./pages/Home";
import LoginPage, { action as loginAction } from "./pages/Login";
import SignupPage, { action as signupAction } from "./pages/Signup";
import { userLoader } from "./utils/auth";
import LogoutAction from "./pages/Logout";
import ContributionListPage, {
  loader as contributionsLoader,
} from "./pages/ContributionList";
import NewContributionPage, {
  action as newContribAction,
  loader as getUserLoader,
} from "./pages/NewContribution";
import ErrorPage from "./pages/Error";
import RewardsListPage, { loader as rewardsLoader } from "./pages/RewardsList";
import ProtectedRoute from "./components/ProtectedRoute";

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    id: "root",
    loader: userLoader,
    errorElement: <ErrorPage />,
    children: [
      { index: true, element: <HomePage />, loader: fridgesLoader },
      {
        path: "users",
        children: [
          { path: "login", element: <LoginPage />, action: loginAction },
          { path: "signup", element: <SignupPage />, action: signupAction },
          { path: "logout", action: LogoutAction },
          {
            path: "contributions",
            element: <ProtectedRoute />,
            children: [
              {
                index: true,
                element: <ContributionListPage />,
                loader: contributionsLoader,
              },
              {
                path: "new",
                element: <NewContributionPage />,
                action: newContribAction,
                loader: getUserLoader,
              },
            ],
          },
        ],
      },
      {
        path: "rewards",
        element: <ProtectedRoute />,
        children: [
          {
            index: true,
            element: <RewardsListPage />,
            loader: rewardsLoader,
          },
        ],
      },
    ],
  },
]);

export default function App() {
  return <RouterProvider router={router} />;
}
