import React, {
    Component
} from 'react';
import PropTypes from 'prop-types';
import {
    withStyles
} from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import {
    Link
} from 'react-router-dom'
import Typography from '@material-ui/core/Typography'
import Grid from "@material-ui/core//Grid";


const styles = theme => ({
    root: {
        backgroundColor: theme.palette.secondary.main,
        flex: 1,
        width: '100%',
    },
    infoBox: {
        height: "auto",
        left: 0,
        margin: "auto",
        maxWidth: 400,
        minWidth: 320,
        position: "absolute",
        right: 0,
        top: "20%",
    },

    logo: {
        borderRadius: '100%',
        border: '' + theme.palette.primary.dark + ' solid 1%',
        backgroundColor: theme.palette.primary.light,
        width: '40vmin',
        height: '40vmin',
    },
    description: {
        padding: 10,
        width: '40vmin',
        textAlign: 'justify'
    },
    button: {
        padding: 10,
        textAlign: "center"
    }
});


class Home extends Component {

    render() {
        const {
            classes
        } = this.props;
        return (<div className={classes.root}>

                <Grid container>
                <Grid container className={classes.infoBox}>
                    <Grid item>
                    <div className={classes.logo}>

                    </div>
                    </Grid>
                    <Grid item>
                    <div className={classes.description}>
                        <Typography variant="body1">
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit.Assumenda distinctio doloremque
                            ducimus
                            esse hic, illo incidunt neque perspiciatis quod repellat, repudiandae rerum sit vitae.Aut
                            incidunt inventore iste molestiae voluptatum ?
                        </Typography>
                    </div>
                    </Grid>

                   {/* <div className={classes.button}>
                        <Link to='/gallery'>
                            <Button variant="contained" color="primary">
                                Get Started!
                            </Button>
                        </Link>
                    </div>*/}

                </Grid>
                    <Grid container>
                        Grid
                    </Grid>
                </Grid>
            </div>
        );
    }
}


Home.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Home);