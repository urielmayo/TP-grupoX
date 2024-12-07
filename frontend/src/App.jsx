import { createBrowserRouter, RouterProvider } from "react-router-dom";

// pages
import MainLayout from "./layouts/MainLayout";
import HomePage from "./pages/Home";
import LoginPage from "./pages/Login";
import SignupPage from "./pages/Signup";
import LogoutAction from "./pages/Logout";
import ContributionListPage from "./pages/ContributionList";
import NewContributionPage from "./pages/NewContribution";
import ContributionDetailPage from "./pages/ContributionDetail";
import ErrorPage from "./pages/Error";
import RewardsListPage from "./pages/RewardsList";
import ProfilePage from "./pages/Profile";
import TechniciansListPage from "./pages/Technicians";
import NewTechnicianPage from "./pages/NewTechnician";
import TechnicianDetailPage from "./pages/TechniciansDetail";
import UpdateTechnicianPage from "./pages/UpdateTechnician";
import CoefficientsPage from "./pages/Coefficients";

// actions
import { loginAction } from "./pages/Login";
import { signupAction } from "./pages/Signup";
import { newTechnicianAction } from "./pages/NewTechnician";
import { newContribAction } from "./pages/NewContribution";
import { updateTechicianAction } from "./pages/UpdateTechnician";
import { updateCoefficientAction } from "./pages/Coefficients";
// loaders
import { userLoader } from "./utils/auth";
import { contributionLoader } from "./loaders/contributionsLoader";
import { profileLoader } from "./loaders/profileLoader";
import { rewardsLoader } from "./loaders/rewardsLoader";
import { fridgesLoader } from "./loaders/fridgesLoader";
import { coefficientsLoader } from "./loaders/coefficientsLoader";
import {
  neighbourhoodsLoader,
  techniciansLoader,
  technicianLoader,
} from "./loaders/techniciansLoader";

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
        path: "coefficients",
        element: <CoefficientsPage />,
        loader: coefficientsLoader,
        action: updateCoefficientAction,
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
            loader: neighbourhoodsLoader,
          },
          {
            path: ":id",
            id: "techicianDetail",
            loader: technicianLoader,
            children: [
              {
                index: true,
                element: <TechnicianDetailPage />,
              },
              {
                path: "update",
                element: <UpdateTechnicianPage />,
                loader: neighbourhoodsLoader,
                action: updateTechicianAction,
              },
            ],
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
