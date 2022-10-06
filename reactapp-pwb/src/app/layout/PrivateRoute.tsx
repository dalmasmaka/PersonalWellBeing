
import { ComponentType } from "react";
import { Redirect, Route, RouteComponentProps, RouteProps } from "react-router";
import { toast } from "react-toastify";
import { useAppSelector } from "../ourApp/configureApp";

interface Props extends RouteProps {
  component: ComponentType<RouteComponentProps<any>> | ComponentType<any>;
  roles?: string[];
}

export default function PrivateRoute({ component: Component, roles, ...rest }: Props) {
  const { user } = useAppSelector(state => state.account);
  return (
    <Route {...rest} render={props => {
      //We check if it's authenticated
      
      if (!user || !user?.roles?.includes('Admin') ) {
        //if not we redirect it to the login
        return <Redirect to={{ pathname: "/login", state: { from: props.location } }} />
      }
      //we check to see if there is any role that i parsed to private route
      if (roles && !roles?.some(r => user.roles?.includes(r))) {
        //if not -> not authorised
        toast.error('Not authorised to access this area');
        return <Redirect to={{ pathname: "/" }} />
      }

      return <Component {...props} />
    }}
    />
  );
}