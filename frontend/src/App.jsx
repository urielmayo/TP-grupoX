import { createBrowserRouter, RouterProvider } from "react-router-dom";

// pages
import MainLayout from "./layouts/MainLayout";
import HomePage from "./pages/Home";
import LoginPage from "./pages/Login";
import SignupPage from "./pages/Signup";
import LogoutAction from "./pages/Logout";
import ContributionListPage from "./pages/contributions/ContributionList";
import NewContributionPage from "./pages/contributions/NewContribution";
import ContributionDetailPage from "./pages/contributions/ContributionDetail";
import ErrorPage from "./pages/Error";
import RewardsListPage from "./pages/RewardsList";
import ProfilePage from "./pages/Profile";
import TechniciansListPage from "./pages/technicians/Technicians";
import NewTechnicianPage from "./pages/technicians/NewTechnician";
import TechnicianDetailPage from "./pages/technicians/TechniciansDetail";
import UpdateTechnicianPage from "./pages/technicians/UpdateTechnician";
import CoefficientsPage from "./pages/Coefficients";
import BulkContributionsPage from "./pages/contributions/BulkContributions";
import FridgesListPage from "./pages/fridges/FridgesList";
import FridgeVisitPage from "./pages/fridges/FridgeVisit";
import FridgeIncidentPage from "./pages/fridges/FridgeIncident";
import ReportsPage from "./pages/Reports";
import FridgeDetailPage from "./pages/fridges/FridgesDetail";
import TechnicianVisitPage from "./pages/technicians/TechnicianVisit";

// actions
import { loginAction } from "./pages/Login";
import { signupAction } from "./pages/Signup";
import { newTechnicianAction } from "./pages/technicians/NewTechnician";
import { newContribAction } from "./pages/contributions/NewContribution";
import { updateTechicianAction } from "./pages/technicians/UpdateTechnician";
import { updateCoefficientAction } from "./pages/Coefficients";
import { bulkContribAction } from "./pages/contributions/BulkContributions";
import { createFridgeVisitAction } from "./pages/fridges/FridgeVisit";
import { fridgeIncidentAction } from "./pages/fridges/FridgeIncident";
import { reportsAction } from "./pages/Reports";
import { technicianVisitAction } from "./pages/technicians/TechnicianVisit";
// loaders
import { userLoader } from "./utils/auth";
import { contributionLoader } from "./loaders/contributionsLoader";
import { profileLoader } from "./loaders/profileLoader";
import { benefitsLoader } from "./loaders/benefitsLoader";
import { reportsLoader } from "./loaders/reportsLoader";
import {
  fridgesLoader,
  fridgeLoader,
  fridgeVisitLoader,
} from "./loaders/fridgesLoader";
import { coefficientsLoader } from "./loaders/coefficientsLoader";
import { bulkContribLoader } from "./loaders/bulkContribLoader";
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
        path: "bulk-contributions",
        element: <BulkContributionsPage />,
        action: bulkContribAction,
        loader: bulkContribLoader,
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
        loader: benefitsLoader,
      },
      {
        path: "reports",
        element: <ReportsPage />,
        loader: reportsLoader,
        action: reportsAction,
      },
      {
        path: "fridges",
        children: [
          {
            index: true,
            element: <FridgesListPage />,
            loader: fridgesLoader,
          },
          {
            path: ":id",
            element: <FridgeDetailPage />,
            loader: fridgeLoader,
            children: [
              {
                path: "visit",
                element: <FridgeVisitPage />,
                loader: fridgeVisitLoader,
                action: createFridgeVisitAction,
              },
              {
                path: "incident",
                element: <FridgeIncidentPage />,
                action: fridgeIncidentAction,
              },
            ],
          },
        ],
      },
      {
        path: "visit/:uuid",
        element: <TechnicianVisitPage />,
        action: technicianVisitAction,
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
