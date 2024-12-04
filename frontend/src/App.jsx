import { createBrowserRouter, RouterProvider } from "react-router-dom";

import MainLayout from "./layouts/MainLayout";
import HomePage from "./pages/Home";
import LoginPage, { loginAction } from "./pages/Login";
import SignupPage, { signupAction } from "./pages/Signup";
import LogoutAction from "./pages/Logout";
import ContributionListPage from "./pages/ContributionList";
import NewContributionPage, { newContribAction } from "./pages/NewContribution";
import ContributionDetailPage from "./pages/ContributionDetail";
import ErrorPage from "./pages/Error";
import RewardsListPage from "./pages/RewardsList";
import ProfilePage from "./pages/Profile";
import TechniciansListPage from "./pages/Technicians";

import { newTechnicianAction } from "./components/technicians/NewTechnician";

import { userLoader } from "./utils/auth";
import { contributionLoader } from "./loaders/contributionsLoader";
import { profileLoader } from "./loaders/profileLoader";
import { rewardsLoader } from "./loaders/rewardsLoader";
import { fridgesLoader } from "./loaders/fridgesLoader";
import {
  newTechnicianLoader,
  techniciansLoader,
} from "./loaders/techniciansLoader";
import NewTechnicianPage from "./pages/NewTechnician";

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
          { path: "me", element: <ProfilePage />, loader: profileLoader },
        ],
      },
      {
        path: "contributions",
        id: "contributions",
        loader: profileLoader,
        element: <ContributionListPage />,
        children: [
          {
            path: "new",
            element: <NewContributionPage />,
            action: newContribAction,
            loader: fridgesLoader,
          },
          {
            path: ":id",
            element: <ContributionDetailPage />,
            loader: contributionLoader,
          },
        ],
      },
      {
        path: "rewards",
        element: <RewardsListPage />,
        loader: rewardsLoader,
      },
      {
        path: "technicians",
        loader: techniciansLoader,
        element: <TechniciansListPage />,
        children: [
          {
            path: "new",
            element: <NewTechnicianPage />,
            action: newTechnicianAction,
            loader: newTechnicianLoader,
          },
        ],
      },
    ],
  },
]);

export default function App() {
  return <RouterProvider router={router} />;
}

// TODO: vista de perfil, carga masiva
