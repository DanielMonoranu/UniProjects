import { useEffect, useState } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import './App.css';
import { claim } from './authentication/auth.model';
import AuthenticationContext from './authentication/AuthenticationContext';
import { getClaims } from './authentication/JWTHandler';
import Menu from './Menu';
import routes from './route-config';
import configureInterceptor from './utilities/httpInterceptors';
import configureValidations from './Validations';

configureValidations();
configureInterceptor();

function App() {
  const [claims, setClaims] = useState<claim[]>([]);

  useEffect(() => { //pt a ramane logati
    setClaims(getClaims());
  }, [])

  function isAdmin() {
    return claims.findIndex(claim => claim.name === 'role' && claim.value === 'admin') > -1;
  }

  return (
    <BrowserRouter>
      <AuthenticationContext.Provider value={{ claims, update: setClaims }}>
        <Menu />
        <div className='container' >
          <Switch>
            {routes.map(route =>
              <Route key={route.path} path={route.path} exact={route.exact}>
                {route.isAdmin && !isAdmin() ? <> You are not allowed to see this page</> : <route.component />}
              </Route>
            )}

          </Switch>
        </div >
        <footer className='bd-footer py-5 mt-5 bg-light'>
          <div className='container'>Dani - React Movies {new Date().getFullYear().toString()}</div>
        </footer>
      </AuthenticationContext.Provider>
    </BrowserRouter>
  );
}

export default App;
